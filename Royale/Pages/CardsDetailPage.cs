using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsDetailPage : PageBase
    {
        public readonly CardsDetailPageMap Map;

        public CardsDetailPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsDetailPageMap(driver);
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }

    }

    public class CardsDetailPageMap
    {
        IWebDriver _driver;

        public CardsDetailPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardName => _driver.FindElement(By.CssSelector("div[class*='cardName']"));

        public IWebElement CardCategory => _driver.FindElement(By.CssSelector("div[class*='card__rarity']"));

        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("div[class*='rarityCaption']"));

        
    }
}