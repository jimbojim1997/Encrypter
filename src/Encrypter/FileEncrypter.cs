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

        public static void Encrypt(string path, string key, bool deleteOnFinish = false, bool shreadOnFinish = false)
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
                return;
            }
        }

        public static void Decrypt(string path, string key, bool deleteOnFinish = false, bool shreadOnFinish = false)
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
        }

        private static void CreateZipFromFile(string path, string resultPath)
        {
            string fileName = new FileInfo(path).Name;
            using (ZipArchive zip = ZipFile.Open(resultPath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(path, fileName, CompressionLevel.Optimal);
            }
        }

        private static void CreateZipFromDirectory(string path, string resultPath)
        {
            ZipFile.CreateFromDirectory(path, resultPath, CompressionLevel.Optimal, true);
        }

        private static void ExtractFromZip(string path, string resultPath)
        {
            ZipFile.ExtractToDirectory(path, resultPath);
        }

        private static void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }else if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }
    }
}
