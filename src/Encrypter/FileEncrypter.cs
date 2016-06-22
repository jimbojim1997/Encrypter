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

            return EncrypterStatus.OK;
        }

        public static EncrypterStatus Decrypt(string path, string key, bool deleteOnFinish = false, bool shreadOnFinish = false)
        {
            if (File.Exists(path))
            {
                if (new FileInfo(path).Extension == tempExtension)
                {
                    FileInfo file = new FileInfo(path);
                    string directory = file.DirectoryName;
                    string zipName = directory + @"\" + Path.GetFileNameWithoutExtension(path) + tempExtension;



                    ExtractFromZip(zipName, directory);
                    Delete(zipName);
                }
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
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }

    enum EncrypterStatus
    {
        OK,
        doesNotExist,
        incorrectKey,
        targetExists
    }
}
