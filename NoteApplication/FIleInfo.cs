using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteApplication
{
    public class FileInfo
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }

        public FileInfo(string filePath)
        {
            Content = System.IO.File.ReadAllText(filePath);
            Name = Path.GetFileName(filePath);
            FilePath = filePath;
        }

        private bool FileExists()
        {
            return System.IO.File.Exists(Name);
        }

        public void ReadContent()
        {
            if (FileExists())
            {
                Content = System.IO.File.ReadAllText(Name);
            }
            else
            {
                Content = string.Empty;
            }
        }
    }
    public static class GameFormExtensions
    {
        public static bool SaveUpdates(this FileInfo finfo, string fileName, string content)
        {
            string directoryPath = Path.GetDirectoryName(finfo.FilePath);
            string newFilePath = Path.Combine(directoryPath, fileName);
            if (!fileName.EndsWith(".txt"))
            {
                return false;
            }
            finfo.Name = fileName;
            finfo.Content = content;

            if (!string.Equals(finfo.FilePath, newFilePath, StringComparison.OrdinalIgnoreCase))
            {
                File.Move(finfo.FilePath, newFilePath);
                finfo.FilePath = newFilePath;
            }

            File.WriteAllText(newFilePath, finfo.Content);
            return true;
        }
    }
}
