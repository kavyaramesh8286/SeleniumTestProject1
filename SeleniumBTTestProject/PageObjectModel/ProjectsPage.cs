using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumBTTestProject.PageObjectModel
{
    /// <summary>
    ///  Class to store the webelements for the Projects page.
    /// </summary>
    public class ProjectsPage
    {

        private readonly IWebDriver _driver = null!;
        public ProjectsPage(IWebDriver driver)
        {
            _driver = driver;
        }


        /// <summary>
        /// Gets the WebElement for Projects
        /// </summary>
        public IWebElement TAAssessment
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.LinkText("TAAssessment1")));
                        //(By.XPath("//a[@class='g5nvnr-3 hHGSBv']//span[text()='TAAssessment1']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the text of Projects
        /// </summary>
        public string ProjectName
        {
            get
            {

                return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='css-1eus1fj']"))).Text;
            }
        }
    }
}