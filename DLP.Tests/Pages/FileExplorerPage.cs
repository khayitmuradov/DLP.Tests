using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using Keys = OpenQA.Selenium.Keys;

namespace DLP.Tests.Pages
{
    public class FileExplorerPage
    {
        private WindowsDriver<WindowsElement> driver;
        private WebDriverWait wait;


        public FileExplorerPage(WindowsDriver<WindowsElement> driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public void OpenFileExplorer()
        {
            Process.Start("explorer.exe");
            Thread.Sleep(3000);
        }

        public void NavigateToFolder(string path)
        {
            var searchBox = wait.Until(driver => ((WindowsDriver<WindowsElement>)driver).FindElementByAccessibilityId("TextBox"));
            searchBox.Click();
            Thread.Sleep(3000);

            searchBox.SendKeys(path + Keys.Enter);
            Thread.Sleep(3000);
            Console.WriteLine($"✅ Successfully navigated to {path}.");
        }

        public void NavigateToFolder2ndTime(string path)
        {
            Thread.Sleep(1000);
            driver.Keyboard.SendKeys(Keys.Control + "l");
            Thread.Sleep(500);

            var searchBox = wait.Until(driver => ((WindowsDriver<WindowsElement>)driver).FindElementByAccessibilityId("TextBox"));
            searchBox.Clear();
            Thread.Sleep(500);
            searchBox.SendKeys(path + Keys.Enter);
            Thread.Sleep(3000);
        }

        public void CopyFile(string fileName)
        {
            var fileElement = driver.FindElementByAccessibilityId("0");
            fileElement.Click();
            Thread.Sleep(2000);
            driver.Keyboard.SendKeys(Keys.Control + "c");
            Thread.Sleep(2000);
        }

        public void PasteFile()
        {
            driver.Keyboard.SendKeys(Keys.Control + "v");
            Thread.Sleep(3000);
        }
    }
}
