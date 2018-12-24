using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace LBAuth
{
    class Helper
    {
        TimeSpan timeout = new TimeSpan(00, 00, 15);
        public IWebDriver driver { set; get; }
        public WebDriverWait wait { set; get; }

        public Helper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, timeout);
            PageFactory.InitElements(driver, this);
        }

        public void FindByLinkTextClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(x))).Click();
        }

        public void FindByXpathClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(x))).Click();
        }

        public void FindByCssClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(x))).Click();
        }

        public void FindByClassClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(x))).Click();
        }

        public void FindByNameClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(x))).Click();
        }

        public void FindByIdClick(string x)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(x))).Click();
        }

        public IWebElement FindByLink(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(x)));
        }

        public IWebElement FindByXpath(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(x)));
        }

        public IWebElement FindByCss(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(x)));
        }

        public IWebElement FindByClass(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(x)));
        }

        public IWebElement FindByName(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(x)));
        }

        public IWebElement FindById(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(x)));
        }

        public void FindByXpathSendkeys(string x, string y)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(x))).SendKeys(y);
        }

        public void FindByCssSendkeys(string x, string y)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(x))).SendKeys(y);
        }

        public void FindByClassSendkeys(string x, string y)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(x))).SendKeys(y);
        }

        public void FindByNameSendkeys(string x, string y)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(x))).SendKeys(y);
        }

        public void FindByIdSendkeys(string x, string y)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(x))).SendKeys(y);
        }

        public string FindByXpathText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(x))).Text;
        }

        public string FindByCssText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(x))).Text;
        }

        public string FindByClassText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(x))).Text;
        }

        public string FindByNameText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(x))).Text;
        }

        public string FindByIdText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(x))).Text;
        }

        public string FindByLinkText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(x))).Text;
        }

        public string FindByPartialLinkText(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText(x))).Text;
        }

        public ReadOnlyCollection<IWebElement> FindAllByLink(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.LinkText(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllByXpath(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllByCss(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllByClass(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllByName(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllById(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(x)));
        }

        public ReadOnlyCollection<IWebElement> FindAllByTag(string x)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName(x)));
        }

        public void WaitPageLoad()
        {
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitAjaxLoad()
        {
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0").Equals("complete"));
        }
    }
}
