using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using Keys = OpenQA.Selenium.Keys;

namespace DLP.Tests.Pages
{
    public class FileExplorerPage
    {
        private readonly WindowsDriver<WindowsElement> driver;
        private readonly WebDriverWait wait;


        public FileExplorerPage(WindowsDriver<WindowsElement> driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public WindowsElement searchBox => (WindowsElement)wait.Until(drv => drv.FindElement(By.Name("Address Bar")));
        public WindowsElement fileElement => (WindowsElement)wait.Until(drv => drv.FindElement(By.Name("maxfiy_malumotlar.txt")));

        public void OpenFileExplorer()
        {
            Process.Start("explorer.exe");
            Thread.Sleep(3000);
        }

        public void NavigateToFolder(string path)
        {
            searchBox.Click();

            searchBox.SendKeys(path + Keys.Enter);
            Console.WriteLine($"Successfully navigated to {path}.");
        }

        public void NavigateToFolder2ndTime(string path)
        {
            driver.Keyboard.SendKeys(Keys.Control + "l");

            searchBox.Clear();
            searchBox.SendKeys(path + Keys.Enter);
        }

        public void CopyFile(string fileName)
        {
            fileElement.Click();
            driver.Keyboard.SendKeys(Keys.Control + "c");
        }

        public void PasteFile()
        {
            driver.Keyboard.SendKeys(Keys.Control + "v");
            Thread.Sleep(3000);
        }
    }
}
