using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace Encrypter
{
    static class FileEncrypter
    {
        private const string tempExtension = ".tmp";
        private const string encryptedExtension = ".enc";

        public static EncrypterStatus Encrypt(string path, string key, bool deleteOnFinish = false, bool shreadOnFinish = false)
        {
            string directory;
            string zipName;
            string resultingName;
            if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                string fileName = Path.GetFileNameWithoutExtension(path);
                directory = file.DirectoryName;
                zipName = directory + @"\" + fileName + tempExtension;
                resultingName = directory + @"\" + fileName + encryptedExtension;

                if (File.Exists(zipName))
                {
                    Delete(zipName);
                }

                CreateZipFromFile(path, zipName);

            }else if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                string fileName = dir.Name;
                directory = dir.Parent.FullName;
                zipName = directory + @"\" + fileName + tempExtension;
                resultingName = directory + @"\" + fileName + encryptedExtension;

                if (File.Exists(zipName))
                {
                    Delete(zipName);
                }

                CreateZipFromDirectory(path, zipName);

            }
            else
            {
                return EncrypterStatus.doesNotExist;
            }

            EncrypterStatus encryptionResult = CryptFile(zipName, resultingName, key, EncrypterMode.Encrypt);
            Delete(zipName);

            if (deleteOnFinish)
            {
                Delete(path);
            }

            return encryptionResult;
        }

        public static EncrypterStatus Decrypt(string path, string key, bool deleteOnFinish = false, bool shreadOnFinish = false)
        {
            if (File.Exists(path))
            {
                if (new FileInfo(path).Extension == encryptedExtension)
                {
                    FileInfo file = new FileInfo(path);
                    string directory = file.DirectoryName;
                    string zipName = directory + @"\" + Path.GetFileNameWithoutExtension(path) + tempExtension;

                    EncrypterStatus decryptionResult = CryptFile(path, zipName, key, EncrypterMode.Decrypt);
                    ExtractFromZip(zipName, directory);

                    Delete(zipName);

                    if (deleteOnFinish)
                    {
                        Delete(path);
                    }

                    return decryptionResult;
                }
                else
                {
                    return EncrypterStatus.unable;
                }
            }
            else
            {
                return EncrypterStatus.doesNotExist;
            }
        }

        private static EncrypterStatus CryptFile(string path, string resultPath, string key, EncrypterMode mode)
        {
            if(!File.Exists(path))
            {
                return EncrypterStatus.doesNotExist;
            }

            if (File.Exists(resultPath))
            {
                return EncrypterStatus.targetExists;
            }

            try
            {
                byte[] keyByteArray = Encoding.ASCII.GetBytes(key);
                byte[] md5 = MD5.Create().ComputeHash(keyByteArray);
                byte[] sha256 = SHA256.Create().ComputeHash(keyByteArray);

                Aes aes = AesCryptoServiceProvider.Create();
                aes.IV = md5;
                aes.Key = sha256;

                ICryptoTransform crypto;
                if(mode == EncrypterMode.Encrypt)
                {
                     crypto = aes.CreateEncryptor();
                }
                else
                {
                    crypto = aes.CreateDecryptor();
                }

                using (FileStream fsIn = new FileStream(path, FileMode.Open))
                using (FileStream fsOut = new FileStream(resultPath, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(fsOut, crypto, CryptoStreamMode.Write))
                {
                    fsOut.SetLength(fsIn.Length);

                    byte[] data = new byte[fsIn.Length];
                    fsIn.Read(data, 0, data.Length);

                    cryptoStream.Write(data, 0, data.Length);
                }
            }
            catch (InvalidDataException)
            {
                return EncrypterStatus.incorrectKey;
            }
            catch
            {
                return EncrypterStatus.unable;
            }
            return EncrypterStatus.OK;
        }

        private static bool CreateZipFromFile(string path, string resultPath)
        {
            string fileName = new FileInfo(path).Name;
            try
            {
                using (ZipArchive zip = ZipFile.Open(resultPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(path, fileName, CompressionLevel.Optimal);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool CreateZipFromDirectory(string path, string resultPath)
        {
            try
            {
                ZipFile.CreateFromDirectory(path, resultPath, CompressionLevel.Optimal, true);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool ExtractFromZip(string path, string resultPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(path, resultPath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool Delete(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

    enum EncrypterStatus
    {
        OK,
        doesNotExist,
        incorrectKey,
        targetExists,
        unable
    }

    enum EncrypterMode
    {
        Encrypt,
        Decrypt
    }
}
