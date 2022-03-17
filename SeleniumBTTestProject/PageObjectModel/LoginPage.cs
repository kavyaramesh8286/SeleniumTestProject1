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
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[2]/form/div[3]/button/span")));
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
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[2]/form/div[3]/button/span/span")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Signup/Login
        /// </summary>
        public string LoginOrSignUp
        {
            get
            {

                return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[1]/h5"))).Text;
            }
        }

        /// <summary>
        /// Gets the WebElement for SignUp Button.
        /// </summary>
        public IWebElement SignUpButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[2]/form/div[6]/button/span/span")));
                }
                catch
                {
                    return null!;
                }
            }
        }


        /// <summary>
        /// Gets the WebElement for verify email page
        /// </summary>
        public string VerifyEmailPage
        {
            get
            {

                return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[1]/h5"))).Text;
            }
        }




        /*
         public void Test1()
         {
             driver.Navigate().GoToUrl("");
             driver.FindElement(By.Id("username")).SendKeys("maharana.chinku@gmail.com");
             driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[2]/form/div[3]/button/span")).Click();
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             driver.FindElement(By.Id("password")).SendKeys("Password123#");
             driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/div[2]/div/section/div[2]/form/div[3]/button/span/span")).Click();

             Console.WriteLine("Test is Passed");
             Assert.Pass();

         }
        */
    }
}