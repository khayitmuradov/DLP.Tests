using DLP.Tests.Pages;
using DLP.Tests.Utils;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace DLP.Tests.Tests
{
    [TestClass]
    public class FileOperationsTests
    {
        private WindowsDriver<WindowsElement>? session;
        private WebDriverWait? wait;
        private FileExplorerPage? fileExplorer;
        private string? usbDriveLetter;
        private string destinationFileName = "maxfiy_malumotlar.txt";
        private string folderPath = "C:\\TestFiles";
        private string usbPath = "D:\\datalar";


        [TestInitialize]
        public void Setup()
        {
            session = ConfigManager.CreateSession();
            wait = new WebDriverWait(session, TimeSpan.FromSeconds(50));
            fileExplorer = new FileExplorerPage(session, wait);

            usbDriveLetter = ConfigManager.GetUSBDriveLetter();

            Assert.IsFalse(string.IsNullOrEmpty(usbDriveLetter), "No USB drive detected!");
        }

        [TestMethod]
        public void CopyFileToUSB()
        {
            fileExplorer?.OpenFileExplorer();
            fileExplorer?.NavigateToFolder(folderPath);
            fileExplorer?.CopyFile(destinationFileName);
            fileExplorer?.NavigateToFolder2ndTime(usbPath);
            fileExplorer?.PasteFile();

            Assert.IsTrue(FileIntegrityChecker.IsFileCopied(usbPath, destinationFileName), "File copy failed!");
        }

        [TestCleanup]
        public void Cleanup()
        {
            session?.Quit();
        }
    }
}
