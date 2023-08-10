﻿using AventStack.ExtentReports;
using ConsoleApp2.Pages;
using ConsoleApp2.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace ConsoleApp2.Tests
{
    [TestFixture]
    public class EducationTests : CommonDriver
    {
        EducationPage educationpageobj = new();

        [OneTimeSetUp]
        public void SetupExtentReports()
        {
            //var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string reportPath = $@"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\Reports\_{timestamp}.html";
            string reportPath = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\Reports\";
            ExtentReportManager.InitializeExtentReports(reportPath);

        }

        [OneTimeTearDown]
        public void FlushExtentReports()
        {
            ExtentReportManager.FlushExtentReports();
        }

        [SetUp]
        public void SetUpActions()
        {
            //open chrome browser and enter url
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //login 
            LoginPage loginpageobj = new();
            loginpageobj.LoginSteps();
        }
        [Test, Order(1)]
        public void CreateEducation()
        {

            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Education\AddEducationJson.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(EducationJsonFile);

            // Deserialize the JSON into an object
            //List<ModelJsonData> educationdata = JsonConvert.DeserializeObject<List<ModelJsonData>>(jsonText);
            //ModelJsonData edudata = educationdata.ElementAt(0);

            var educationData = JsonConvert.DeserializeObject<EducationJsonData>(jsonText);
            //var educationData = JsonConvert.DeserializeObject<List<EducationJsonData>>(jsonText);
            //dynamic educationData = JsonConvert.DeserializeObject(jsonText);

            foreach (var data in educationData.Create)
            {
                string UniversityName = data.UniversityName;
                string Country = data.Country;
                string Degree = data.Degree ?? string.Empty;
                string Title = data.Title;
                int Year = data.Year;

                ExtentReportManager.CreateTest("Adding records to Education", $"UniversityName: {UniversityName}, Country: {Country}, Degree: {Degree}, Title: {Title}, Year: {Year}");
                ExtentReportManager.LogTestStep(Status.Info, "Running the test");
                ExtentReportManager.LogTestStep(Status.Info, $"Filled education fields with data: {UniversityName}, {Country}, {Degree}, {Title}, {Year}");


                educationpageobj.AddEducation(UniversityName, Country, Degree, Title, Year);

                // Take a screenshot and attach it to the report                
                var screenshotPath = ScreenshotManager.TakeScreenshot(driver, $"TestData-{Degree}-{Title}-{Year}");
                ExtentReportManager.LogTestStepWithScreenShot(Status.Info, "Screenshot", screenshotPath);
            }
        }

        [Test, Order(2)]
        public void UpdateEduPositiveTest()
        {
            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Education\PositiveUpdateEdu.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(EducationJsonFile);

            // Deserialize the JSON into an object
            var educationData = JsonConvert.DeserializeObject<EducationJsonData>(jsonText);

            for (int i = 1; i <= 2; i++)
            {
                List<EducationRecords>? updates = educationData.GetType().GetProperty($"PositiveUpdate{i}")?.GetValue(educationData) as List<EducationRecords>;

                if (updates != null)
                {
                    foreach (var data in updates)
                    {
                        string UniversityName = data.UniversityName;
                        string Country = data.Country;
                        string Degree = data.Degree; //?? string.Empty;
                        string Title = data.Title;
                        int Year = data.Year;

                        if (i == 1)
                        {
                            educationpageobj.EditEduPositiveUpdate1(UniversityName, Country, Degree, Title, Year);
                        }
                        else if (i == 2)
                        {
                            educationpageobj.EditEduPositiveUpdate2(UniversityName, Country, Degree, Title, Year);
                        }
                    }
                }
            }

            //foreach (var data in educationData.Update1)
            //{
            //    string UniversityName = data.UniversityName;
            //    string Country = data.Country;
            //    string Degree = data.Degree; //?? string.Empty;
            //    string Title = data.Title;
            //    int Year = data.Year;

            //    educationpageobj.EditEducationUpdate1(UniversityName, Country, Degree, Title, Year);                
            //}     // if you dont want to use the for loop above the this foreach has to used for every update                   
        }

        [Test, Order(3)]
        public void UpdateEduNegativeTest()
        {
            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Education\NegativeUpdateEdu.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(EducationJsonFile);

            // Deserialize the JSON into an object
            var educationData = JsonConvert.DeserializeObject<EducationJsonData>(jsonText);

            for (int i = 1; i <= 4; i++)
            {
                List<EducationRecords>? updates = educationData.GetType().GetProperty($"NegativeUpdate{i}")?.GetValue(educationData) as List<EducationRecords>;

                if (updates != null)
                {
                    foreach (var data in updates)
                    {
                        string UniversityName = data.UniversityName;
                        string Country = data.Country;
                        string Degree = data.Degree; //?? string.Empty;
                        string Title = data.Title;
                        int Year = data.Year;

                        if (i == 1)
                        {
                            educationpageobj.EditEduNegativeUpdate1(UniversityName, Country, Degree, Title, Year);
                        }
                        else if (i == 2)
                        {
                            educationpageobj.EditEduNegativeUpdate2(UniversityName, Country, Degree, Title, Year);
                        }
                        else if (i == 3)
                        {
                            educationpageobj.EditEduNegativeUpdate3(UniversityName, Country, Degree, Title, Year);
                        }
                        else if (i == 4)
                        {
                            educationpageobj.EditEduNegativeUpdate4(UniversityName, Country, Degree, Title, Year);
                        }
                    }
                }
            }
        }

        [Test, Order(4)]
        public void DeleteEducation()
        {
            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Education\DeleteEducation.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(EducationJsonFile);

            // Deserialize the JSON into an object
            var educationData = JsonConvert.DeserializeObject<EducationJsonData>(jsonText);

            foreach (var data in educationData.Delete1)
            {
                string UniversityName = data.UniversityName;
                string Country = data.Country;
                string Degree = data.Degree; //?? string.Empty;
                string Title = data.Title;
                int Year = data.Year;

                educationpageobj.RemoveEducation(UniversityName, Country, Degree, Title, Year);

            }

        }
        [Test, Order(5)]
        public void CheckCancelFunction()
        {
            educationpageobj.CancelFunction();
        }

        [TearDown]
        public void SetDownActions()
        {
            driver.Close();

        }

    }

}

