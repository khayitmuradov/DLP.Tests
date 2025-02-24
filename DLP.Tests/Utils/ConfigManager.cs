using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace DLP.Tests.Utils
{
    public class ConfigManager
    {

        public static WindowsDriver<WindowsElement> CreateSession()
        {
            DesiredCapabilities appCapabs = new DesiredCapabilities();
            appCapabs.SetCapability("app", "Root");

            return new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabs);
        }

        public static string GetUSBDriveLetter()
        {
            var removableDrives = DriveInfo.GetDrives()
                .Where(d => d.DriveType == DriveType.Removable && d.IsReady)
                .ToList();

            if (!removableDrives.Any())
            {
                return "No USB drives found!";
            }

            string drive = removableDrives.First().Name.TrimEnd('\\');
            Console.WriteLine($"USB Drive Detected: {drive}");
            return drive;
        }
    }
}
