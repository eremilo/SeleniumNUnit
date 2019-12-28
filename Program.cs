using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    [TestFixture]
    public class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
       { 

       }

        [SetUp]
        public void Initialize()
        {
            driver.Url = "https://careers.veeam.com/";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            CareersPage careersPage = new CareersPage(driver);
            careersPage.choseCountry("Romania");
            careersPage.choseLanguage("English");
            Assert.AreEqual(26, careersPage.getVacancies().Count); 
        }

        [TearDown]
        public void CleanUP()
        {
            driver.Close();
        }
    }
}
