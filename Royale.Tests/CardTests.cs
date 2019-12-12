using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }
        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }
        [Test]
        public void Ice_Spirit_is_on_the_cards_page()
        {
            Assert.Pass();
        }
    }
}