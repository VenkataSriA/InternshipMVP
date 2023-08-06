using AventStack.ExtentReports;
using ConsoleApp2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Pages
{
    public class CertificationPage: CommonDriver
    {
        By profileTab => By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        By certificationTab => By.XPath("//a[text()='Certifications']"); //*[contains(text(), 'Certifications')]
        By addNewButton => By.XPath("//thead/tr/th[4]/div[@class='ui teal button ']"); //addnew certification            
        By addCertification => By.XPath("//input[@name='certificationName']");
        By certifiedFrom => By.XPath("//input[@name='certificationFrom']");
        By certificateYear => By.XPath("//select[@name='certificationYear']");
        By addButton => By.XPath("//div/div[3]/input[@value='Add']"); //add the education inputs
        By cancelButton => By.XPath("//div/div[3]/input[@value='Cancel']");

        public void AddCertification(string Certificate, string CertifiedFrom, int Year) 
        {
            driver.FindElement(profileTab).Click();
            driver.FindElement(certificationTab).Click();
            driver.FindElement(addNewButton).Click();

            Actions action = new(driver);
            action.SendKeys(Keys.PageDown).Perform();

            //add certification name
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='certificationName']", 7);
            driver.FindElement(addCertification).Click();
            driver.FindElement(addCertification).SendKeys(Certificate);

            //click on country list
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='certificationFrom']", 7);
            driver.FindElement(certifiedFrom).Click();
            driver.FindElement(certifiedFrom).SendKeys(CertifiedFrom);
  
            //click on year of graduation year list
            driver.FindElement(certificateYear).Click();
            driver.FindElement(certificateYear).SendKeys(Year.ToString());

            //add and save education
            driver.FindElement(addButton).Click();

            //check for message that new Education is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text            
            string expectedMessage1 =   Certificate + " has been added to your certification";
            string expectedMessage2 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage3 = "Duplicated data";
            string expectedMessage4 = "This information is already exist.";            
            string expectedMessage5 = "has been added to your certification";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4).Or.EqualTo(expectedMessage5));
            //Assert.AreEqual(expectedMessage, actualMessage, "Check for error message");

            // Take a screenshot and attach it to the report                
            var screenshotPath = ScreenshotManager.TakeScreenshot(driver, $"TestData-{Certificate}-{CertifiedFrom}-{Year}");
            ExtentReportManager.LogTestStepWithScreenShot(Status.Info, "Screenshot", screenshotPath);

            //CLOSE THE POPUP MESSAGE BOX
            By closeMessageBoxButton = By.XPath("//a[@class='ns-close']");
            driver.FindElement(closeMessageBoxButton).Click();

            if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4)
            {
                //click on cancel button

                driver.FindElement(cancelButton).Click();
            }
        }

        public void EditCertification(string Certificate, string CertifiedFrom, int Year)
        {
            ExtentReportManager.CreateTest("Editing records to Certification", $"CerificateName: {Certificate}, CertifiedBy: {CertifiedFrom}, Year: {Year}");
            ExtentReportManager.LogTestStep(Status.Info, "Running the test");
            ExtentReportManager.LogTestStep(Status.Info, $"Filled Certification fields with data: {Certificate}, {CertifiedFrom}, {Year}");

            Actions action = new(driver);
            action.SendKeys(Keys.PageDown).Perform();
                     
            //add certification name
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='certificationName']", 7);
            driver.FindElement(addCertification).Clear();
            driver.FindElement(addCertification).SendKeys(Certificate);

            //click on certfied from
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='certificationFrom']", 7);
            driver.FindElement(certifiedFrom).Clear();
            driver.FindElement(certifiedFrom).SendKeys(CertifiedFrom);

            //click on year of certification year list
            driver.FindElement(certificateYear).Click();
            driver.FindElement(certificateYear).SendKeys(Year.ToString());

            //update and save education
            By updateButton = By.XPath("//input[@value='Update']");
            driver.FindElement(updateButton).Click();

            //check for message that new Education is updated successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text            
            string expectedMessage1 = Certificate + " has been updated to your certification";
            string expectedMessage2 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage3 = "This information is already exist.";
            string expectedMessage4 = "has been updated to your certification";

            // Take a screenshot and attach it to the report                
            var screenshotPath = ScreenshotManager.TakeScreenshot(driver, $"TestData-{Certificate}-{CertifiedFrom}-{Year}");
            ExtentReportManager.LogTestStepWithScreenShot(Status.Info, "Screenshot", screenshotPath);

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
            //Assert.AreEqual(expectedMessage, actualMessage, "Check for error message");

            //CLOSE THE POPUP MESSAGE BOX
            By closeMessageBoxButton = By.XPath("//a[@class='ns-close']");
            driver.FindElement(closeMessageBoxButton).Click();

            if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3)
            {
                //click on cancel button
                IWebElement updateCancelButton = driver.FindElement(By.XPath("//input[2][@value='Cancel']"));
                updateCancelButton.Click();
            }

        }
        public void EditCertificationUpdate1(string Certificate, string CertifiedFrom, int Year)
        {
            driver.FindElement(profileTab).Click();
            
            //find and click on education tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(certificationTab).Click();

            try
            {
                //find the required record to edit    1st row
                //IWebElement updateIcon = driver.FindElement(By.XPath("//tbody[tr[td[text()='Automation'] and td[text()='QA']]]//span[1]"));                
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }

        public void EditCertificationUpdate2(string Certificate, string CertifiedFrom, int Year)
        {
            
            try
            {
                //find the required record to edit    2nd row                               
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[2]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }
        public void EditCertificationUpdate3(string Certificate, string CertifiedFrom, int Year)
        {           

            try
            {
                //find the required record to edit    3rd row                                
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[3]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }
        public void EditCertificationUpdate4(string Certificate, string CertifiedFrom, int Year)
        {
            
            try
            {
                //find the required record to edit   4th row                                
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[4]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }
        public void EditCertificationUpdate5(string Certificate, string CertifiedFrom, int Year)
        {
            try
            {
                //find the required record to edit    5th row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[5]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }
        public void EditCertificationUpdate6(string Certificate, string CertifiedFrom, int Year)
        {

            try
            {
                //find the required record to edit    1st row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditCertification(Certificate, CertifiedFrom, Year);
        }
       
        
        public void RemoveCertification(string Certificate, string CertifiedFrom, int Year)
        {
            driver.FindElement(profileTab).Click();

            //find and click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(certificationTab).Click();

            ExtentReportManager.CreateTest("Deleting records to certification", "Containg Selenium,Lambda Test");
            ExtentReportManager.LogTestStep(Status.Info, "Running the test");


            try
            {
                //IWebElement deleteIcon = driver.FindElement(By.XPath("//tbody[tr[td[text()='Selenium'] and td[text()='Lambda Test']]]//span[2]"));
                IWebElement deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{Certificate}'] and td[text()='{CertifiedFrom}']]]//span[2]"));
                deleteIcon.Click();

                //check for message that new certification is deleted successfully
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);
                string expectedMessage1 = Certificate + " has been deleted from your certification";
                if (actualMessage == expectedMessage1)
                {                    
                    Console.WriteLine("Record Deleted");
                }
                // Take a screenshot and attach it to the report                
                var screenshotPath = ScreenshotManager.TakeScreenshot(driver, "Deleted Record");
                ExtentReportManager.LogTestStepWithScreenShot(Status.Info, "Screenshot", screenshotPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Element not found");
            }
        }

        public void CancelFunction()
        {
            driver.FindElement(profileTab).Click();

            //find and click on certification tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(certificationTab).Click();

            driver.FindElement(addNewButton).Click();
            driver.FindElement(cancelButton).Click();
            Console.WriteLine("Cancel functtion checked for add new certification");
            //find the required record to edit    1st row
            IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div/div/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i"));
            updateIcon.Click();
            //click on cancel button
            IWebElement updateCancelButton = driver.FindElement(By.XPath("//input[2][@value='Cancel']"));
            updateCancelButton.Click();
            Console.WriteLine("Cancel function checked for upadte certification");
        }

    }
}
