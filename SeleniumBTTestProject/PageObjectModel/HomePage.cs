using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumBTTestProject.PageObjectModel
{
    /// <summary>
    ///  Class to store the webelements for the Home page.
    /// </summary>
    public class HomePage
    {

        private readonly IWebDriver _driver = null!;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }


        /// <summary>
        /// Gets the WebElement for Projects
        /// </summary>
        public IWebElement ClickProjects
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//button[@class='css-13uzbj5']/span[text()='Projects']")));
                        //(By.CssSelector("div[class='css-d6vpf6'] button[class='css-13uzbj5'][type='button']")));

                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for View All Projects
        /// </summary>
        public IWebElement ViewAllProjects
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//a[@class='css-f6nuwn']//span[text()='View all projects']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

    }
}
