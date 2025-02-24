using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;


namespace DLP.Tests.Pages
{
    public class EmailServicePage
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private readonly WebDriverWait _wait;

        public EmailServicePage(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public WindowsElement searchBox => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Address and search bar")));
        public WindowsElement composeButton => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Compose")));
        public WindowsElement recipientsField => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("To recipients")));
        public WindowsElement subjectField => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Subject")));
        public WindowsElement messageBody => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Message Body")));
        public WindowsElement attachButton => (WindowsElement)_wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@class, 'J-J5-Ji J-Z-I-Kv-H')]")));
        public WindowsElement fileToAttach => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("maxfiy_malumotlar.txt")));
        public WindowsElement openButton => (WindowsElement)_wait.Until(drv => drv.FindElement(By.ClassName("Button")));
        public WindowsElement sendButton => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Send ‪(Ctrl-Enter)‬")));
        public WindowsElement sentModal => (WindowsElement)_wait.Until(drv => drv.FindElement(By.Name("Message sent")));

        public void OpenEmailService()
        {
            searchBox.SendKeys("https://mail.google.com");
            searchBox.SendKeys(Keys.Enter);
        }

        public void ComposeEmail(string recipient, string subject, string message)
        {
            Thread.Sleep(6000);
            composeButton.Click();
            recipientsField.SendKeys(recipient);
            subjectField.SendKeys(subject);
            messageBody.SendKeys(message);
        }

        public void AttachFile()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys(Keys.Enter).Perform();

            Thread.Sleep(2000);
            fileToAttach.Click();
            openButton.Click();
        }

        public void SendEmail()
        {
            sendButton.Click();
            Thread.Sleep(5000);
        }
    }
}
