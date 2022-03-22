using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumBTTestProject.PageObjectModel
{
    /// <summary>
    ///  Class to store the webelements for the Issues page.
    /// </summary>
    public class IssuesPage
    {

        private readonly IWebDriver _driver = null!;
        public IssuesPage(IWebDriver driver)
        {
            _driver = driver;
        }


        /// <summary>
        /// Gets the WebElement for Create button.
        /// </summary>
        public IWebElement CreateIssueButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("createGlobalItem")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for the new bug in list
        /// </summary>
        public IWebElement NewBugInList
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='sc-1h00v3i-0 dHKpG']//tr[1]//td[2]")));
                }
                catch
                {
                    return null!;
                }
            }
        }
        
        /// <summary>
        /// Gets the WebElement for the Summary in Issue list
        /// </summary>
        public IWebElement SummaryFromIssueList
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//table[@class='sc-1h00v3i-0 dHKpG']//tr[1]//td[3]")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Search Field
        /// </summary>
        public IWebElement SearchField
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Name("search")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for More Options 
        /// </summary>
        public IWebElement MoreOptions
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//table[@class='sc-1h00v3i-0 dHKpG']//tr[1]//td[12]")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Delete
        /// </summary>
        public IWebElement Delete
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='css-nqsyso']//button[@id='issueaction-delete-issue']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Click Delete Confirm
        /// </summary>
        public IWebElement DeleteConfirmButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("delete-issue-submit")));
                }
                catch
                {
                    return null!;
                }
            }
        }


        /// <summary>
        /// Gets the WebElement for Click Delete Confirm
        /// </summary>
        /// 
        public IWebElement ClearSearch
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='dzwo7b-0 bEDeIN']//button[@data-test-id='searchfield.ui.searchfield-icon.clear-button']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for page display
        /// </summary>
        /// 
        public IWebElement PageDisplay
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.TagName("p")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Projects Hyperlink
        /// </summary>
        /// 
        public IWebElement ProjectsHyperlink
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.PartialLinkText("Project")));
                }
                catch
                {
                    return null!;
                }
            }
        }
    }
}