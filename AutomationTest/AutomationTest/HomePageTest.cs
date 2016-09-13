using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;

namespace AutomationTest
{
    [TestFixture]
    public class HomePageTest : TestBase
    {

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(GlobalsWords.URLPage);
            Assert.AreEqual(GlobalsWords.TitlePageHome, driver.Title, msgerror(GlobalsWords.TitlePageHome, driver.Title));
        }

        [Test]
        public void TestCase001_ValidateSectionMainLinks()
        {
            ValidateLinks(GlobalsWords.MenuXPathLink1, GlobalsWords.MenuTextLink1);
            ValidateLinks(GlobalsWords.MenuXPathLink2, GlobalsWords.MenuTextLink2);
            ValidateLinks(GlobalsWords.MenuXPathLink3, GlobalsWords.MenuTextLink3);
            ValidateLinks(GlobalsWords.MenuXPathLink4, GlobalsWords.MenuTextLink4);
            ValidateLinks(GlobalsWords.MenuXPathLink5, GlobalsWords.MenuTextLink5);
            ValidateLinks(GlobalsWords.MenuXPathLink6, GlobalsWords.MenuTextLink6);
            ValidateLinks(GlobalsWords.MenuXPathLink7, GlobalsWords.MenuTextLink6);
        }

        public void ValidateLinks(string XpathLink, string TextExpected)
        {
            var MainElement = driver.FindElement(By.XPath(XpathLink));
            Assert.AreEqual(TextExpected, MainElement.Text, msgerror(TextExpected, MainElement.Text));
        }


    }
}
