using AventStack.ExtentReports;
using ConsoleApp2.Pages;
using ConsoleApp2.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tests
{
    [TestFixture]
    public class CertificationTests : CommonDriver
    {
        CertificationPage certificationpageobj = new ();

        [OneTimeSetUp]
        public void SetupExtentReports()
        {
            
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
            LoginPage loginpageobj = new ();
            loginpageobj.LoginSteps();
        }
        [Test, Order(1)]
        public void CreateCertification()
        {
            string CertificationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\CertificationJson.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(CertificationJsonFile);

            // Deserialize the JSON into an object
            //List<ModelJsonData> educationdata = JsonConvert.DeserializeObject<List<ModelJsonData>>(jsonText);
            //ModelJsonData edudata = educationdata.ElementAt(0);

            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);
            //var educationData = JsonConvert.DeserializeObject<List<EducationJsonData>>(jsonText);
            //dynamic educationData = JsonConvert.DeserializeObject(jsonText);

            foreach (var data in certificationData.Create)
            {
                string Certificate = data.Certificate;
                string CertifiedFrom = data.CertifiedFrom;                
                int Year = data.Year;

                ExtentReportManager.CreateTest("Adding records to Certification", $"CerificateName: {Certificate}, CertifiedBy: {CertifiedFrom}, Year: {Year}");
                ExtentReportManager.LogTestStep(Status.Info, "Running the test");
                ExtentReportManager.LogTestStep(Status.Info, $"Filled Certification fields with data: {Certificate}, {CertifiedFrom}, {Year}");

                
                certificationpageobj.AddCertification(Certificate, CertifiedFrom, Year);

                
            }
        }

        [Test, Order(2)]
        public void UpdateCertification()
        {

            string CertificationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\UpdateCertification.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(CertificationJsonFile);
           
            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);

            for (int i = 1; i <= 6; i++)
            {
                List<CertificationRecords>? updates = certificationData.GetType().GetProperty($"Update{i}")?.GetValue(certificationData) as List<CertificationRecords>;

                if (updates != null)
                {
                    foreach (var data in updates)
                    {
                        string Certificate = data.Certificate;
                        string CertifiedFrom = data.CertifiedFrom;
                        int Year = data.Year;

                        if (i == 1)
                        {
                            certificationpageobj.EditCertificationUpdate1(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 2)
                        {
                            certificationpageobj.EditCertificationUpdate2(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 3)
                        {
                            certificationpageobj.EditCertificationUpdate3(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 4)
                        {
                            certificationpageobj.EditCertificationUpdate4(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 5)
                        {
                            certificationpageobj.EditCertificationUpdate5(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 6)
                        {
                            certificationpageobj.EditCertificationUpdate6(Certificate, CertifiedFrom, Year);
                        }

                    }
                }
            }
        }
    
        [Test, Order(3)]
        public void DeleteCertificaction()
        {
            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\DeleteCertification.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(EducationJsonFile);

            // Deserialize the JSON into an object
            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);

            foreach (var data in certificationData.Delete1)
            {
                string Certificate = data.Certificate;
                string CertifiedFrom = data.CertifiedFrom;
                int Year = data.Year;

                certificationpageobj.RemoveCertification(Certificate, CertifiedFrom, Year);

            }
            
        }
        [Test, Order(4)]
        public void CheckCancelFunction()
        {
            certificationpageobj.CancelFunction();
        }

        [TearDown]
        public void SetDownActions()
        {
            driver.Close();

        }

    }
}

