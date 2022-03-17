using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using SeleniumBTTestProject.Configurations;
using SeleniumBTTestProject.PageObjectModel;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace SeleniumBTTestProject.TestScripts
{
    /// <summary>
    /// Test script for test cases.
    /// </summary>
    [TestFixture]
    public class TestingScriptShould
    {

        public IWebDriver _driver = null!;
        public TestContext? TestContext { get; set; }

        ///<summary>
        ///Starts the browser.
        /// </summary>
        [SetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(7));
            _driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromMinutes(7));
            _driver.Manage().Window.Maximize();
        }

        //[TearDown]
        //public void Close_Browser()
        //{
        //    _driver.Quit();
        //}

        ///<summary>
        ///Test Script to navigate to View All Projects page
        /// </summary>
        [Test]
        [Order(1)]
        public void Projects()
        {
            LoginShould applicationLoginCall = new(_driver);

            if (applicationLoginCall.Login())
            {
               
                Console.WriteLine("Login Success");
                HomePage homePage = new (_driver);                
                homePage.ClickProjects.Click();
                Thread.Sleep(500);
                homePage.ViewAllProjects.Click();
                Thread.Sleep(5000);
                string title = _driver.Title;
                Console.WriteLine("Page Title is :- " + title);
            }
            else
            {
                Console.WriteLine("Invalid User.Please register and login again.");
            }

        }
    }
}
