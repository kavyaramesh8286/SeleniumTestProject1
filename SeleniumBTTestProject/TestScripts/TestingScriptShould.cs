using System;
using System.Threading;
using NUnit.Framework;
using SeleniumBTTestProject.PageObjectModel;
using SeleniumBTTestProject.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumBTTestProject.TestScripts
{
    /// <summary>
    /// Test script for test cases.
    /// </summary>
    [TestFixture]
    public class TestingScriptShould
    {

        private IWebDriver _driver = null!;
        private string bugID = string.Empty;
        private ExtentReports extent = null!;
        private ExtentTest logger = null!;
        private ExtentHtmlReporter reporter;
        public ITakesScreenshot screenshotDriver = null!;

        public TestingScriptShould()
        {
            reporter = new ExtentHtmlReporter(ConfigParameters.FilePath);
            reporter.Config.ReportName = "BT Test Report";
            reporter.Config.DocumentTitle = "BT Test Result";
            reporter.Config.EnableTimeline = true;
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            reporter.AnalysisStrategy = AnalysisStrategy.Test;

            extent = new ExtentReports();
            extent.AttachReporter(reporter);
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AddSystemInfo("Operating System", "Windows 11");
        }

        ///<summary>
        ///Starts the browser.
        /// </summary>
        [OneTimeSetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new();
            options.AddArgument("no-sandbox");
            _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(7));
            _driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(7));
            _driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(60));
            _driver.Manage().Window.Maximize();
            screenshotDriver = _driver as ITakesScreenshot;

        }

        [OneTimeTearDown]
        public void Close_Browser()
        {
            extent.Flush();
            _driver.Quit();
        }

        ///<summary>
        ///Test Script to navigate to Projects page
        /// </summary>
        [Test]
        [Order(1)]
        public void Projects()
        {
            logger = extent.CreateTest("Navigation to View All Projects page");
            try
            { 
                LoginShould applicationLoginCall = new(_driver);
                if (applicationLoginCall.Login())
                {
                    Console.WriteLine("Login Success");
                    logger.Info("Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                    HomePage homePage = new(_driver);
                    homePage.ClickProjects.Click();
                    homePage.ViewAllProjects.Click();
                    Thread.Sleep(500);
                    string title = _driver.Title;
                    Console.WriteLine("Page Title is :-  " + title);
                    logger.Info("Page Title is :- " + title, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                    ProjectsPage projectsPage = new(_driver);
                    projectsPage.TAAssessment.Click();
                    Thread.Sleep(3000);
                    string title1 = _driver.Title;
                    Console.WriteLine("Page Title is :- " + title1);
                    logger.Info("Page Title is :-  " + title1, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                    string projectName = projectsPage.ProjectName;
                    Assert.That(projectName, Is.EqualTo("Project:TAAssessment1"));
                    Console.WriteLine("Project name is validated correctly:- " + projectName);
                    logger.Pass("Project name is validated correctly:-  " + projectName, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());

                }
                else
                {
                    Console.WriteLine("Invalid Username/Password.Please register or recheck password and login again.");
                    logger.Fail("Invalid Username/Password.Please register or recheck password and login again.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                    Close_Browser();
                    extent.Flush();
                    return;
                }
            }
            catch (Exception)
            {
                logger.Fail("Test Run Failed. Validate the error", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Close_Browser();
                extent.Flush();
                throw;
            }
        }

        ///<summary>
        ///Test Script to create a bug
        /// </summary>
        [Test]
        [Order(2)]
        public void CreateBug()
        {
            logger = extent.CreateTest("Create a Bug");
            try
            {
                IssuesPage issuesPage = new(_driver);
                issuesPage.CreateIssueButton.Click();
                Thread.Sleep(3000);
                CreateFrame createFrame = new(_driver);
                string createFrametitle = createFrame.CreateFrameTitle;
                Console.WriteLine("Frame name is validated correctly:- " + createFrametitle);
                logger.Info("Create New Issue window is displayed with page title :-  " + createFrametitle, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Thread.Sleep(500);
                string projectNameIs = createFrame.ProjectNameDropdownValue.Text;
                Assert.That(projectNameIs, Is.EqualTo("TAAssessment1"));
                Console.WriteLine("Project dropdown field is pre-selected as:- " + projectNameIs);
                logger.Info("Project dropdown field is pre-selected as:-  " + projectNameIs, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());

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

                IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
                jse.ExecuteScript("arguments[0].innerHTML=arguments[1]", createFrame.IssueDescription, "Issue1 Description is the Web Page not loading. Severity: Highest. ETA: 30th March.");

                Actions keyAction = new(_driver);
                keyAction.KeyDown(Keys.PageDown);
                Thread.Sleep(2000);
                createFrame.PriorityDropdownValue.Click();
                createFrame.PriorityHighest.Click();

                IJavaScriptExecutor jse1 = (IJavaScriptExecutor)_driver;
                jse1.ExecuteScript("arguments[0].innerHTML=arguments[1]", createFrame.EnvironmentDesc, "Environment: UAT");

                createFrame.DueDateCalender.Click();
                Thread.Sleep(3000);
                createFrame.DueDate.Click();
                createFrame.FinalCreateButton.Click();
                bugID = createFrame.BugID.GetAttribute("data-issue-key");
                Console.WriteLine("New Bug ID Generated is:- " + bugID);
                logger.Pass("New Bug ID Generated is:- " + bugID, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                _driver.Navigate().Refresh();

                string newBugIdInList = issuesPage.NewBugInList.Text;
                Console.WriteLine("New Bug ID is successfully displayed in the list. Bug ID is:- " + newBugIdInList);
                logger.Pass("New Bug ID is successfully displayed in the list. Bug ID is:- " + newBugIdInList, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());

                string bugSummaryFromList = issuesPage.SummaryFromIssueList.Text;
                if (bugSummaryFromList == issueSummary)
                {
                    Console.WriteLine("Summary of new bug in list is same as the summary entered while creating the bug: '" + bugSummaryFromList + "'");
                    logger.Pass("Summary of new bug in list is same as the summary entered while creating the bug: '" + bugSummaryFromList + "'", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                }
                else
                {
                    Console.WriteLine("Summary entered is: " + issueSummary + " \nBut Summary displayed in list is: " + bugSummaryFromList);
                    logger.Fail("Summary entered is: " + issueSummary + " \nBut Summary displayed in list is: " + bugSummaryFromList, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                }
                Thread.Sleep(5000);
            }
            catch(Exception)
            {
                logger.Fail("Test Run Failed. Validate the error", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Close_Browser();
                extent.Flush();
                throw;
            }
        }
        
        ///<summary>
        ///Test Script to Search a Bug
        /// </summary>
        [Test]
        [Order(3)]
        public void SearchBug()
        {
            logger = extent.CreateTest("Search a Bug");
            try
            {
                IssuesPage issuesPage = new(_driver);
                issuesPage.SearchField.SendKeys(bugID);
                Actions keyAction = new(_driver);
                keyAction.KeyDown(Keys.Enter);
                Thread.Sleep(3000);
                Console.WriteLine("The Searched Bug ID: '" + bugID + "'  is displayed in the grid Successfully.");
                logger.Pass("The Searched Bug ID: '" + bugID + "'  is displayed in the grid Successfully.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Thread.Sleep(5000);
            }
            catch(Exception)
            {
                logger.Fail("Test Run Failed. Validate the error", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Close_Browser();
                extent.Flush();
                throw;
            }
        }
        
        ///<summary>
        ///Test Script to Delete a bug
        /// </summary>
        [Test]
        [Order(4)]
        public void DeleteBug()
        {
            logger = extent.CreateTest("DeleteBug");
            try
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
                Thread.Sleep(3000);
                Console.WriteLine("The Searched Bug ID:' " + bugID + "'  is deleted and not displayed.");
                logger.Pass("The Searched Bug ID: '" + bugID + "'  is deleted and not displayed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                
                issuesPage.ProjectsHyperlink.Click();
                Thread.Sleep(3000);
                logger.Pass("Back to 'Projects' Page is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());    
                
            }
            catch
            {
                logger.Fail("Test Run Failed. Validate the error", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotDriver.GetScreenshot().AsBase64EncodedString).Build());
                Close_Browser();
                extent.Flush();
                throw;
            }
        }
    }
}
