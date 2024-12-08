using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OpenCriticApp_Test {
    [TestClass]
    public class TestClass {
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp() {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestPageLoad() {
            driver.Navigate().GoToUrl("http://localhost:5198");
            Thread.Sleep(5000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            IWebElement h1Element = wait.Until(d => d.FindElement(By.TagName("h1")));
            string title = h1Element.Text;
            string siteTitle = driver.Title;

            Assert.AreEqual("Current Trending Games on OpenCritic", title);
            Assert.AreEqual("OpenCriticApp", siteTitle);
        }

        [TestMethod]
        public void TestGameDetail() { // astro bot
            driver.Navigate().GoToUrl("http://localhost:5198");
            Thread.Sleep(5000);

            var gameLink = driver.FindElement(By.CssSelector("a[href*='/gamedetail/']"));
            gameLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var gameTitle = driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual("Astro Bot", gameTitle);

            var expectedCompanies = new List<string> { "Asobi", "Sony" };
            var companies = driver.FindElements(By.CssSelector(".game-additional-info .platform"));
            foreach (var expectedCompany in expectedCompanies) {
                Assert.IsTrue(companies.Any(company => company.Text.Contains(expectedCompany)));
            }

            // console exclusive
            var expectedConsoles = new List<string> { "PlayStation 5" };
            var consoles = driver.FindElements(By.CssSelector(".game-additional-info .platform"));
            foreach (var expectedConsole in expectedConsoles) {
                Assert.IsTrue(consoles.Any(console => console.Text.Contains(expectedConsole)));
            }

            var expectedGenres = new List<string> { "Platformer" };
            var genres = driver.FindElements(By.CssSelector(".game-additional-info .genre"));
            foreach (var expectedGenre in expectedGenres) {
                Assert.IsTrue(genres.Any(genre => genre.Text.Contains(expectedGenre)));
            }
        }

        [TestMethod]
        public void SearchPageResults() {
            driver.Navigate().GoToUrl("http://localhost:5198");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(5000);

            var searchLink = driver.FindElement(By.CssSelector("a[href*='/search']"));
            searchLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var searchInput = driver.FindElement(By.CssSelector("input[placeholder='Search for games...']"));
            Thread.Sleep(2000);
            searchInput.SendKeys("Astro Bot");
            Thread.Sleep(5000);

            var button = driver.FindElement(By.Name("search"));
            button.Click();
            Thread.Sleep(5000);

            var games = driver.FindElements(By.CssSelector(".game-card"));
            var gameName = games[0].FindElement(By.CssSelector(".game-info h3")).Text;
            Assert.AreEqual("Astro Bot", gameName);
        }

        [TestCleanup]
        public void TearDown() {
            driver.Quit();
        }
    }
}
