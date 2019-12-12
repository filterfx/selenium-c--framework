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
            // 1. go to statsroyale.com
            driver.Url = "https://statsroyale.com";
            // 2. click cards links in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. Assert ice spirit is displayed
            var iceSpirit = driver.FindElement(By.CssSelector("a[href='https://statsroyale.com/card/Ice+Spirit']"));
            Assert.That(iceSpirit.Displayed);
        }
    }
}