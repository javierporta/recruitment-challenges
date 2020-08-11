using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Refactoring.FraudDetection.Common
{
    public static class FilesHandler
    {
        private static string GetFilePath(string fileName, string path="Files", string extension=".txt")
        {
            var folderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var filePath = Path.Combine(folderPath, path, $"{fileName}{extension}");
            return filePath;
        }

        public static string[] GetLinesFromFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            return File.ReadAllLines(filePath);
        }

    }
}
