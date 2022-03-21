using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;



namespace SeleniumBTTestProject.PageObjectModel
{
    /// <summary>
    ///  Class to store the webelements for the login page.
    /// </summary>
    public class LoginPage
    {

        private readonly IWebDriver _driver = null!;
        //private WebDriverWait wait = null!;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Gets the WebElement for UserName field.
        /// </summary>
        public IWebElement UserNameTxtBox
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("username")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Continue Button.
        /// </summary>
        public IWebElement ContinueButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button#login-submit")));
                        
                }
                catch
                {
                    return null!;
                }
            }
        }


        /// <summary>
        /// Gets the WebElement for Password field.
        /// </summary>
        public IWebElement PasswordTxtBox
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Login Button.
        /// </summary>
        public IWebElement LoginButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button#login-submit")));
                        
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the Locator for Signup/Login
        /// </summary>
        public string LoginOrSignUp
        {
            get
            {

                return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[1]/h5"))).Text;
            }
        }
    }
}