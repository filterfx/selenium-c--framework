using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            driver.Url = "https://statsroyale.com";
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
            //driver.Url = "https://statsroyale.com";

            // 2. click cards links in header nav
            //driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            var cardPage = new CardsPage(driver);
            var IceSpirit = cardPage.GoTo().GetCardByName("Ice Spirit");

            // 3. Assert ice spirit is displayed
            //var IceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            Assert.That(IceSpirit.Displayed);
        }

          [Test]
        public void Ice_Spirit_headers_are_correct_on_the_cards_detail_page()
        {
            // 1. go to statsroyale.com
            driver.Url = "https://statsroyale.com";
            // 2. click cards links in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. go to Ice Spirit
            driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();
            // 4. assert basic header stats
            var cardName = driver.FindElement(By.CssSelector("[class*='cardName']")).Text;
            var cardCategories = driver.FindElement(By.CssSelector(".card__rarity")).Text.Split(", ");
            var cardType = cardCategories[0];
            var cardArena = cardCategories[1];
            var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);
        }
    }
}