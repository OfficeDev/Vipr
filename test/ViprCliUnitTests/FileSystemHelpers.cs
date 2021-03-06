using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Vipr.Core;

namespace ViprCliUnitTests
{
    public static class FileSystemHelpers
    {
        public static void WriteFiles(IEnumerable<TextFile> textFileCollection, string workingDirectory = null)
        {
            foreach (var textFile in textFileCollection)
            {
                var filePath = textFile.RelativePath;

                filePath = GetFilePath(workingDirectory, filePath);
                
                File.WriteAllText(filePath, textFile.Contents);
            }
        }

        public static void ValidateTextFiles(IEnumerable<TextFile> textFiles, string workingDirectory = null)
        {
            foreach (var file in textFiles)
            {
                var filePath = file.RelativePath;

                filePath = GetFilePath(workingDirectory, filePath);

                File.ReadAllText(filePath)
                    .Should().Be(file.Contents);
            }
        }

        public static void DeleteFiles(IEnumerable<TextFile> textFiles, string workingDirectory = null)
        {
            foreach (var file in textFiles)
            {
                var filePath = file.RelativePath;

                filePath = GetFilePath(workingDirectory, filePath);

                if(File.Exists(filePath))
                    File.Delete(filePath);
            }
        }

        private static string GetFilePath(string workingDirectory, string filePath)
        {
            if (!String.IsNullOrWhiteSpace(workingDirectory)) filePath = Path.Combine(workingDirectory, filePath);
            return filePath;
        }
    }
}