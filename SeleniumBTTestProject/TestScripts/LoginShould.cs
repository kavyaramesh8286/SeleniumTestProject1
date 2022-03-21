using System;
using NUnit.Framework;
using SeleniumBTTestProject.Configurations;
using SeleniumBTTestProject.PageObjectModel;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBTTestProject.TestScripts
{
    /// <summary>
    /// Test script class for login.
    /// </summary>
    
    [TestFixture]
    public class LoginShould
    {
        private readonly IWebDriver _driver;
        //public TestContext? TestContext { get; set; }



        /// <summary>
        /// Initialize new instance of "LoginShould class.
        /// </summary>
        public LoginShould(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver), "Driver cannot be null");
        }

        ///<summary>
        ///Test case for loging in
        /// </summary>
        public bool Login()
        {
            try
            {

                _driver.Navigate().GoToUrl(ConfigParameters.ApplicationURL);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                LoginPage loginPage = new(_driver);
                loginPage.UserNameTxtBox.SendKeys(ConfigParameters.UserName);
                Thread.Sleep(500);
                loginPage.ContinueButton.Click();
                new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => loginPage.LoginOrSignUp);
                string logintitle = loginPage.LoginOrSignUp;

                if (logintitle == "Log in to your account")
                {
                    loginPage.PasswordTxtBox.SendKeys(ConfigParameters.Password);
                    loginPage.LoginButton.Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
