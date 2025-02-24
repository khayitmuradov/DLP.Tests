using DLP.Tests.Pages;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace DLP.Tests.Tests
{
    [TestClass]
    public class SendEmailToUserTests
    {
        private const string winAppDriverUrl = "http://127.0.0.1:4723";
        private const string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        private WindowsDriver<WindowsElement>? _driver;
        EmailServicePage? _emailServicePage;
        private readonly string? _email;

        public SendEmailToUserTests()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _email = config["EmailCredentials:Username"];
        }

        [TestInitialize]
        public void Setup()
        {
            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability("app", chromePath);
            _driver = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), desiredCapabilities);
            _emailServicePage = new EmailServicePage(_driver);
        }


        [TestMethod]
        public void OpenGoogleChrome()
        {
            _emailServicePage?.OpenEmailService();
            _emailServicePage?.ComposeEmail(_email ?? throw new ArgumentNullException("Email topilmadi"), "o'ta maxfiy ma'lumot yuborayapman", "Bu maxfiy ma'lumot bo'lib, uni hech kimga bera ko'rmang");
            _emailServicePage?.AttachFile();
            _emailServicePage?.SendEmail();

            Assert.IsNotNull(_emailServicePage?.sentModal, "Email was NOT sent successfully");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.Quit();
        }
    }
}