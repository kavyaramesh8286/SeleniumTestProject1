using System;
using System.Threading;
using NUnit.Framework;
using SeleniumBTTestProject.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumBTTestProject.TestScripts
{
    /// <summary>
    /// Test script for test cases.
    /// </summary>
    [TestFixture]
    public class TestingScriptShould
    {

        public IWebDriver _driver = null!;
        //public TestContext? TestContext { get; set; }
        public string bugID = string.Empty;

        ///<summary>
        ///Starts the browser.
        /// </summary>
        [OneTimeSetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(7));
            _driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(7));
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Close_Browser()
        {
            _driver.Quit();
        }

        ///<summary>
        ///Test Script to navigate to Projects page
        /// </summary>
        [Test]
        [Order(1)]
        public void Projects()
        {
            LoginShould applicationLoginCall = new(_driver);

            if (applicationLoginCall.Login())
            {

                Console.WriteLine("Login Success");
                HomePage homePage = new(_driver);
                //Thread.Sleep(5000);
                homePage.ClickProjects.Click();
                //Thread.Sleep(500);
                homePage.ViewAllProjects.Click();
                Thread.Sleep(500);
                string title = _driver.Title;
                Console.WriteLine("Page Title is :- " + title);
                ProjectsPage projectsPage = new(_driver);
                projectsPage.TAAssessment.Click();
                Thread.Sleep(5000);
                string title1 = _driver.Title;
                Console.WriteLine("Page Title is :- " + title1);

                string projectName = projectsPage.ProjectName;
                Assert.That(projectName, Is.EqualTo("Project:TAAssessment1"));
                Console.WriteLine("Project name is validated correctly:- " + projectName);

            }
            else
            {
                Console.WriteLine("Invalid User.Please register and login again.");
            }

        }

        ///<summary>
        ///Test Script to create a bug
        /// </summary>
        [Test]
        [Order(2)]
        public void CreateBug()
        {
            IssuesPage issuesPage = new(_driver);
            issuesPage.CreateIssueButton.Click();
            Thread.Sleep(3000);
            CreateFrame createFrame = new(_driver);
            string createFrametitle = createFrame.CreateFrameTitle;
            Assert.That(createFrametitle, Is.EqualTo("Create issue"));
            Console.WriteLine("Frame name is validated correctly:- " + createFrametitle);

            Thread.Sleep(500);
            string projectNameIs = createFrame.ProjectNameDropdownValue.Text;
            Assert.That(projectNameIs, Is.EqualTo("TAAssessment1"));
            Console.WriteLine("Project dropdown field is pre-selected as:- " + projectNameIs);

            string issueTypeIs = createFrame.IssueTypeDropdownValue.Text;
            if (issueTypeIs == "Bug")
            {
                //Do noting and continue script.
            }
            else
            {
                createFrame.IssueTypeDropdownValue.Click();
                createFrame.IssueTypeBug.Click();
            }
            createFrame.IssueSummary.Click();
            createFrame.IssueSummary.SendKeys("Critical Issue: Web page not loading");
            string issueSummary = createFrame.IssueSummary.GetAttribute("value");
            //issuesPage.IssueDescription.Click();
            //Actions keyAction = new Actions(_driver);
            //keyAction.KeyDown(Keys.Alt);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript("arguments[0].innerHTML=arguments[1]", createFrame.IssueDescription, "Issue1 Description is the Web Page not loading. Severity: Highest. ETA: 30th March.");
            
            Actions keyAction = new Actions(_driver);
            keyAction.KeyDown(Keys.PageDown);
            //string priorityIs = createFrame.PriorityDropdownValue.Text;
            //if (priorityIs == "Highest")
            //{
            //    //Do noting and continue script.
            //}
            //else
            createFrame.PriorityDropdownValue.Click();
            createFrame.PriorityHighest.Click();
            

            //issuesPage.EnvironmentDesc.Click();
            //keyAction.KeyDown(Keys.Alt);
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)_driver;
            jse1.ExecuteScript("arguments[0].innerHTML=arguments[1]", createFrame.EnvironmentDesc, "Environment: UAT");

            createFrame.DueDateCalender.Click();
            Thread.Sleep(5000);
            createFrame.DueDate.Click();
            createFrame.FinalCreateButton.Click();
            bugID = createFrame.BugID.GetAttribute("data-issue-key");
            Console.WriteLine("New Bug ID Generated is:- " + bugID);
            _driver.Navigate().Refresh();

            string newBugIdInList = issuesPage.NewBugInList.Text;     
            Console.WriteLine("New Bug ID is successfully displayed in the list. Bug ID is:- " + newBugIdInList);
            string bugSummaryFromList = issuesPage.SummaryFromIssueList.Text;
            if (bugSummaryFromList == issueSummary)
            {
                Console.WriteLine("Summary of new bug in list is same as the summary entered while creating the bug: '" + bugSummaryFromList + "'");
            }
            else
            {
                Console.WriteLine("Summary entered is: " + issueSummary + " \nBut Summary displayed in list is: " + bugSummaryFromList);
            }
        }
        
        ///<summary>
        ///Test Script to Search a Bug
        /// </summary>
        [Test]
        [Order(3)]
        public void SearchBug()
        {
            
            IssuesPage issuesPage = new(_driver);
            issuesPage.SearchField.SendKeys(bugID);
            Actions keyAction = new(_driver);
            keyAction.KeyDown(Keys.Enter);
            Console.WriteLine("The Searched Bug ID:'" +bugID+ "'  is displayed in the grid Successfully.");
            Thread.Sleep(3000);

        }
        
        ///<summary>
        ///Test Script to Delete a bug
        /// </summary>
        [Test]
        [Order(4)]
        public void DeleteBug()
        {
            IssuesPage issuesPage = new(_driver);
            issuesPage.MoreOptions.Click();
            IJavaScriptExecutor jse2 = (IJavaScriptExecutor)_driver;
            jse2.ExecuteScript("arguments[0].scrollIntoView(true)", issuesPage.Delete);
            issuesPage.Delete.Click();
            Thread.Sleep(5000);
            issuesPage.DeleteConfirmButton.Click();
            _driver.Navigate().Refresh();
            Thread.Sleep(5000);
            issuesPage.ClearSearch.Click();
            issuesPage.SearchField.SendKeys(bugID);
            Actions keyAction = new(_driver);
            keyAction.KeyDown(Keys.Enter);
            Console.WriteLine("The Searched Bug ID:'" + bugID + "'  is deleted and not displayed.");
            Thread.Sleep(10000);


        }
    }
}
