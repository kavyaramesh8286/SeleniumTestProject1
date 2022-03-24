using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumBTTestProject.PageObjectModel
{
    /// <summary>
    ///  Class to store the webelements for the 'Create an Issue' page.
    /// </summary>
    public class CreateFrame
    {

        private readonly IWebDriver _driver = null!;
        public CreateFrame(IWebDriver driver)
        {
            _driver = driver;
        }


        /// <summary>
        /// Gets the WebElement for Create frame title.
        /// </summary>
        public string CreateFrameTitle
        {
            get
            {
                return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists
                    (By.XPath("//h4[@class='css-1aseh1t e1rcei0k1']"))).Text;


            }
        }
        /// <summary>
        /// Gets the WebElement for Project Name Default Value.
        /// </summary>
        public IWebElement ProjectNameDropdownValue
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.Id("issue-create.ui.modal.create-form.project-picker.project-select")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Issue Type Value.
        /// </summary>
        public IWebElement IssueTypeDropdownValue
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.Id("issue-create.ui.modal.create-form.type-picker.issue-type-select")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Issue Type - Bug.
        /// </summary>
        public IWebElement IssueTypeBug
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//div[@class='xkgbo7-1 bjumES']/div[contains(text(),'Bug')]")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Issue summary text field
        /// </summary>
        public IWebElement IssueSummary
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists
                        (By.Name("summary")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Issue Description rich text editor.
        /// </summary>
        public IWebElement IssueDescription
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//div[@id='description-container']//div[@class='ua-chrome ProseMirror pm-table-resizing-plugin']")));

                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Environment rich text editor.
        /// </summary>
        public IWebElement EnvironmentDesc
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//div[@id='environment-container']//div[@class='ua-chrome ProseMirror pm-table-resizing-plugin']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Priority Value.
        /// </summary>
        public IWebElement PriorityDropdownValue
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//label[@id='priority-field-label']/following-sibling::div[@class='i3zfbj-0 keeKqx']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Priority arrow.
        /// </summary>
        public IWebElement PriorityDropdownArrow
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//label[@id='priority-field-label']/following-sibling::div[@class='i3zfbj-0 keeKqx']//span[@class='css-pxzk9z']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Priority-Highest.
        /// </summary>
        public IWebElement PriorityHighest
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//div[@class='xkgbo7-1 bjumES']/div[contains(text(),'Highest')]"))); 
                    //(By.Id("react-select-6-option-0.css-12fvnfc-option]")));
                        
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for DueDateCalender.
        /// </summary>
        public IWebElement DueDateCalender
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable
                        (By.XPath("//div[@id='duedate-container']//div[@class=' css-qgzjb9']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for DueDate.
        /// </summary>
        public IWebElement DueDate
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible
                        (By.XPath("//div[@id='duedate-container']//button[@class='css-16lbez3'][text()='30']")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for Create Button.
        /// </summary>
        public IWebElement FinalCreateButton
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible
                        (By.ClassName("css-goggrm")));
                }
                catch
                {
                    return null!;
                }
            }
        }

        /// <summary>
        /// Gets the WebElement for the created Bug ID.
        /// </summary>
        public IWebElement BugID
        {
            get
            {
                try
                {
                    return new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible
                        (By.XPath("//div[@class=' css-rfofhd']/div")));
                }
                catch
                {
                    return null!;
                }
            }
        }
    }
}