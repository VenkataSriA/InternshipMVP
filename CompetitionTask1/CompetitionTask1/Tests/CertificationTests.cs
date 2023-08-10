using AventStack.ExtentReports;
using ConsoleApp2.Pages;
using ConsoleApp2.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp2.Tests
{
    [TestFixture]
    public class CertificationTests : CommonDriver
    {
        CertificationPage certificationpageobj = new();

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
            LoginPage loginpageobj = new();
            loginpageobj.LoginSteps();
        }
        [Test, Order(1)]
        public void CreateCertification()
        {
            string CertificationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Certification\AddCertificationJson.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(CertificationJsonFile);

            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);

            foreach (var data in certificationData.PositiveCreateTest)
            {
                string Certificate = data.Certificate;
                string CertifiedFrom = data.CertifiedFrom;
                int Year = data.Year;

                ExtentReportManager.CreateTest("Adding records to Certification", $"CerificateName: {Certificate}, CertifiedBy: {CertifiedFrom}, Year: {Year}");
                ExtentReportManager.LogTestStep(Status.Info, "Running the test");
                ExtentReportManager.LogTestStep(Status.Info, $"Filled Certification fields with data: {Certificate}, {CertifiedFrom}, {Year}");

                certificationpageobj.AddCertification(Certificate, CertifiedFrom, Year);
            }
            foreach (var data in certificationData.NegativeCreateTest)
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
        public void PositiveUpdateCertification()
        {

            string CertificationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Certification\PositiveUpdateCerti.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(CertificationJsonFile);

            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);

            for (int i = 1; i <= 2; i++)
            {
                List<CertificationRecords>? updates = certificationData.GetType().GetProperty($"PositiveUpdate{i}")?.GetValue(certificationData) as List<CertificationRecords>;

                if (updates != null)
                {
                    foreach (var data in updates)
                    {
                        string Certificate = data.Certificate;
                        string CertifiedFrom = data.CertifiedFrom;
                        int Year = data.Year;

                        if (i == 1)
                        {
                            certificationpageobj.EditCertiPositiveUpdate1(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 2)
                        {
                            certificationpageobj.EditCertiPositiveUpdate2(Certificate, CertifiedFrom, Year);
                        }

                    }
                }
            }
        }
        [Test, Order(3)]
        public void NegativeUpdateCertification()
        {
            string CertificationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Certification\NegativeUpdateCerti.json";
            // Read the JSON file
            string jsonText = File.ReadAllText(CertificationJsonFile);

            var certificationData = JsonConvert.DeserializeObject<CertificationJsonData>(jsonText);

            for (int i = 1; i <= 4; i++)
            {
                List<CertificationRecords>? updates = certificationData.GetType().GetProperty($"NegativeUpdate{i}")?.GetValue(certificationData) as List<CertificationRecords>;

                if (updates != null)
                {
                    foreach (var data in updates)
                    {
                        string Certificate = data.Certificate;
                        string CertifiedFrom = data.CertifiedFrom;
                        int Year = data.Year;

                        if (i == 1)
                        {
                            certificationpageobj.EditCertiNegativeUpdate1(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 2)
                        {
                            certificationpageobj.EditCertiNegativeUpdate2(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 3)
                        {
                            certificationpageobj.EditCertiNegativeUpdate3(Certificate, CertifiedFrom, Year);
                        }
                        else if (i == 4)
                        {
                            certificationpageobj.EditCertiNegativeUpdate4(Certificate, CertifiedFrom, Year);
                        }

                    }
                }
            }
        }

        [Test, Order(4)]
        public void DeleteCertificaction()
        {
            string EducationJsonFile = @"C:\IDconnect\InternshipMVP\CompetitionTask1\CompetitionTask1\JsonData\Certification\DeleteCertification.json";
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
        [Test, Order(5)]
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

