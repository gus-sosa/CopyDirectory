using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace CopyDirectory.Core
{
    public class DirectoryHandler
    {
        public event Action<string> NewFileCopied;

        public enum OperationResult
        {
            SourceFolderDoesNotExist = 2,
            TargetFolderDoesNotExist = 3,
            NonEmptyTarget = 4,
            GeneralError = 5,
            Succesful = 0
        }

        public OperationResult CopyDirectory(string source, string target)
        {
            if (!Directory.Exists(source))
                return OperationResult.SourceFolderDoesNotExist;
            if (!Directory.Exists(target))
                return OperationResult.TargetFolderDoesNotExist;
            if (Directory.GetFiles(target).Length > 0 || Directory.GetDirectories(target).Length > 0)
                return OperationResult.NonEmptyTarget;

            try
            {
                CopyDirectoryRecur(source, target);
            }
            catch (Exception e)
            {
                return OperationResult.GeneralError;
            }

            return OperationResult.Succesful;
        }

        private void CopyDirectoryRecur(string source, string target)
        {
            foreach (string filePath in Directory.EnumerateFiles(source))
            {
                string targetFilePath = Path.Combine(target, Path.GetFileName(filePath));
                File.Copy(Path.Combine(source, filePath), targetFilePath);
                NewFileCopied?.Invoke(targetFilePath);
            }

            foreach (string directoryPath in Directory.EnumerateDirectories(source))
            {
                string targetDirectoryPath = $"{target}\\{Path.GetFileName(directoryPath)}";
                Directory.CreateDirectory(targetDirectoryPath);
                CopyDirectoryRecur(directoryPath, targetDirectoryPath);
            }
        }
    }
}
