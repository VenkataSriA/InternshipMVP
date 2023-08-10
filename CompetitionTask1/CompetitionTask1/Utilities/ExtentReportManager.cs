using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace ConsoleApp2.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports extent_Report;
        private static ExtentTest test;

        public static void InitializeExtentReports(string reportFilePath)
        {
            extent_Report = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportFilePath);
            extent_Report.AttachReporter(htmlReporter);

        }

        public static void CreateTest(string testName, string testDescription)
        {
            test = extent_Report.CreateTest(testName, testDescription);
            //test.AssignCategory(testDescription); 
            test.AssignAuthor(testDescription);
        }

        public static void LogTestStep(Status status, string logMessage)
        {
            test.Log(status, logMessage);
        }
        public static void LogTestStepWithScreenShot(Status status, string logMessage, string screenshotPath)
        {
            test.Log(status, logMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        }
        public static void FlushExtentReports()
        {
            extent_Report.Flush();
        }
    }


    public class ScreenshotManager
    {
        public static string TakeScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotDir = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\ScreenshotImages\";
            string screenshotFileName = $"{screenshotName}_{DateTime.Now:yyyy-MM-dd-HH.mm.ss}.png";
            string screenshotPath = Path.Combine(screenshotDir, screenshotFileName);

            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            return screenshotPath;
        }
    }

}

