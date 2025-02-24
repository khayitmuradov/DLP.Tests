namespace DLP.Tests.Utils
{
    public class FileIntegrityChecker
    {
        public static bool IsFileCopied(string destinationPath, string fileName)
        {
            return File.Exists(Path.Combine(destinationPath, fileName));
        }
    }
}
