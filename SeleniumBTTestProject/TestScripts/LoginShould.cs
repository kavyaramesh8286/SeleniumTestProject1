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

        //set the URL
        /*  #region INITIALIZE
          [SetUp]
          public void StartBrowser()
          {
              ChromeOptions options = new ChromeOptions();
              options.AddArgument("no-sandbox");

              _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(7));
              _driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromMinutes(7));
              _driver.Manage().Window.Maximize();            
          }

          [TearDown]
          public void Close_Browser()
          {
              _driver.Quit();
          }
          #endregion
        */
        ///<summary>
        ///Test case for loging in
        /// </summary>
        public bool Login()
        {
            try
            {

                _driver.Navigate().GoToUrl(ConfigParameters.ApplicationURL);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                LoginPage loginPage = new LoginPage(_driver);
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

                /*if (logintitle == "Sign up for your account")
                {

                    loginPage.SignUpButton.Click();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                    string emailPage = wait.Until(n => loginPage.VerifyEmailPage);
                    Console.WriteLine(emailPage + ".  Verification email sent to the Email ID successfully");
                    _driver.Quit();
                    return false;
                }
                else if (logintitle == "Check your inbox to log in")
                {
                    string emailPage1 = loginPage.VerifyEmailPage;
                    Console.WriteLine(emailPage1 + ".  Verification email sent to the Email ID successfully");
                    _driver.Quit();
                    return false;
                }
                else
                {
                    return false;
                }*/
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
