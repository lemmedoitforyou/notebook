using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication
{
    internal class FileInfo
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

        public bool SaveUpdates(string fileName, string content)
        {
            string directoryPath = Path.GetDirectoryName(FilePath);
            string newFilePath = Path.Combine(directoryPath, fileName);
            if (!fileName.EndsWith(".txt"))
            {
                return false;
            }
            Name = fileName;
            Content = content;

            if (!string.Equals(FilePath, newFilePath, StringComparison.OrdinalIgnoreCase))
            {
                File.Move(FilePath, newFilePath);
                FilePath = newFilePath;
            }

            File.WriteAllText(newFilePath, Content);
            return true;
        }
    }
}
