using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    internal class CareersPage
    {
        private IWebDriver driver;

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal void choseCountry(String country)
        {
            driver.FindElement(By.Id("country-element")).Click();
            ReadOnlyCollection<IWebElement> listOfcountry = driver.FindElements(By.CssSelector("#country-element div.scroller-content span"));
            foreach (IWebElement element in listOfcountry)
            {
                if (element.Text == country)
                {
                    element.Click();
                    break;
                }
            }
        }

        internal ReadOnlyCollection<IWebElement> getVacancies()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".load-more-button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".hide.load-more-button.content-loader-button")));
            return driver.FindElements(By.CssSelector(".vacancies-blocks-col"));
        }

        internal void choseLanguage(string language)
        {
            driver.FindElement(By.Id("language")).Click();
            ReadOnlyCollection<IWebElement> listOfLanguage = driver.FindElements(By.CssSelector(".controls-checkbox"));
            foreach (IWebElement element in listOfLanguage)
            {
                if (element.Text == language)
                {
                    element.Click();
                    break;
                }
            }
            driver.FindElement(By.CssSelector("#language div.container a")).Click();
        }
    }
}