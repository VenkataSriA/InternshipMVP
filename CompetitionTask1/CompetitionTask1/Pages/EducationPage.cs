using AventStack.ExtentReports;
using ConsoleApp2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace ConsoleApp2.Pages
{
    public class EducationPage : CommonDriver
    {

        static By addNewButton => By.XPath("//thead/tr/th[6]/div[@class='ui teal button ']"); //addnew education        
        static By profileTab => By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        static By educationTab => By.XPath("//form/div/a[text()='Education']");
        static By addCollege => By.XPath("//input[@name='instituteName']");
        static By countryList => By.XPath("//select[@name='country']");
        static By titleList => By.XPath("//select[@name='title']");
        static By degreeName => By.XPath("//input[@name='degree']");
        static By graduationYear => By.XPath("//select[@name='yearOfGraduation']");
        static By addButton => By.XPath("//div/div[3]/div/input[@value='Add']"); //add the education inputs
        static By cancelButton => By.XPath("//div/div[3]/div/input[@value='Cancel']");

        public void GoToProfilePage()
        {
            // go to hi user dropdown
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 5);
            IWebElement userDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            userDropdown.Click();

            // select go to profile from drop down
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]", 7);
            IWebElement profileOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));
            profileOption.Click();

        }
        public void AddEducation(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            //GoToProfilePage();
            driver.FindElement(profileTab).Click();
            //find and click on education tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(educationTab).Click();

            //click on addnew
            Wait.WaitToBeClickable(driver, "XPath", "//thead/tr/th[6]/div[@class='ui teal button ']", 7);
            driver.FindElement(addNewButton).Click();

            //add college name
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='instituteName']", 7);
            driver.FindElement(addCollege).Click();
            driver.FindElement(addCollege).SendKeys(UniversityName);

            //click on country list
            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='country']", 7);
            driver.FindElement(countryList).Click();
            driver.FindElement(countryList).SendKeys(Country);

            //IWebElement chooseCountryList = driver.FindElement(countryList);
            //SelectElement choosecountryList1 = new SelectElement(chooseCountryList);
            //choosecountryList1.SelectByIndex(Country);

            //click title list
            driver.FindElement(titleList).Click();
            driver.FindElement(titleList).SendKeys(Title);

            //enter degree
            driver.FindElement(degreeName).Click();
            driver.FindElement(degreeName).SendKeys(Degree);

            //click on year of graduation year list
            driver.FindElement(graduationYear).Click();
            driver.FindElement(graduationYear).SendKeys(Year.ToString());

            //add and save education
            driver.FindElement(addButton).Click();

            //check for message that new Education is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text            
            string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "Duplicated data";  //year change keeping all other same
            string expectedMessage4 = "This information is already exist."; //all same data
            string expectedMessage5 = "Education information was invalid"; //sapces


            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4).Or.EqualTo(expectedMessage5));
            //Assert.AreEqual(expectedMessage, actualMessage, "Check for error message");

            //CLOSE THE POPUP MESSAGE BOX
            By closeMessageBoxButton = By.XPath("//a[@class='ns-close']");
            driver.FindElement(closeMessageBoxButton).Click();

            if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4 || actualMessage == expectedMessage5)
            {
                //click on cancel button

                driver.FindElement(cancelButton).Click();
            }

            Actions action = new(driver);
            action.SendKeys(Keys.PageDown).Perform();
            Thread.Sleep(500);
        }

        public void EditEducation(string UniversityName, string Country, string Degree, string Title, int Year)
        {

            ExtentReportManager.CreateTest("Update records to Education", $"UniversityName: {UniversityName}, Country: {Country}, Degree: {Degree}, Title: {Title}, Year: {Year}");
            ExtentReportManager.LogTestStep(Status.Info, "Running the test");
            ExtentReportManager.LogTestStep(Status.Info, $"Updated education fields with data: {UniversityName}, {Country}, {Degree}, {Title}, {Year}");

            Actions action = new(driver);
            action.SendKeys(Keys.Down).SendKeys(Keys.Down).Perform();

            //add college name
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='instituteName']", 7);
            driver.FindElement(addCollege).Clear();
            driver.FindElement(addCollege).SendKeys(UniversityName);

            //click on country list
            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='country']", 7);
            driver.FindElement(countryList).Click();
            driver.FindElement(countryList).SendKeys(Country);

            //IWebElement chooseCountryList = driver.FindElement(countryList);
            //SelectElement choosecountryList1 = new SelectElement(chooseCountryList);
            //choosecountryList1.SelectByIndex(Country);   //if u want this change country datatype from string to int

            //click title list
            driver.FindElement(titleList).Click();
            driver.FindElement(titleList).SendKeys(Title);

            //enter degree
            driver.FindElement(degreeName).Clear();
            driver.FindElement(degreeName).SendKeys(Degree);

            //click on year of graduation year list
            driver.FindElement(graduationYear).Click();
            driver.FindElement(graduationYear).SendKeys(Year.ToString());

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
            string expectedMessage1 = "Education as been updated";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "Education information was invalid";
            string expectedMessage4 = "This information is already exist.";

            // Take a screenshot and attach it to the report                
            var screenshotPath = ScreenshotManager.TakeScreenshot(driver, $"TestData-{Degree}-{Title}-{Year}");
            ExtentReportManager.LogTestStepWithScreenShot(Status.Info, "Screenshot", screenshotPath);

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
            //Assert.AreEqual(expectedMessage, actualMessage, "Check for error message");

            //CLOSE THE POPUP MESSAGE BOX
            By closeMessageBoxButton = By.XPath("//a[@class='ns-close']");
            driver.FindElement(closeMessageBoxButton).Click();

            if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4)
            {
                //click on cancel button
                IWebElement cancelUpdate = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                cancelUpdate.Click();
            }
        }

        public void EditEduPositiveUpdate1(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            driver.FindElement(profileTab).Click();

            //find and click on education tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(educationTab).Click();

            try
            {
                //find the required record to edit    1st row
                //IWebElement updateIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{Country}'] and td[text()='{Title}']]]//span[1]"));                
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }

        public void EditEduPositiveUpdate2(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            try
            {
                //find the required record to edit       2nd row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[2]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }

        public void EditEduNegativeUpdate1(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            driver.FindElement(profileTab).Click();

            //find and click on education tab
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(educationTab).Click();
            try
            {
                //find the required record to edit       3rd row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[3]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }
        public void EditEduNegativeUpdate2(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            try
            {
                //find the required record to edit       4th row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[4]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }
        public void EditEduNegativeUpdate3(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            try
            {
                //find the required record to edit       5th row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[5]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }

        public void EditEduNegativeUpdate4(string UniversityName, string Country, string Degree, string Title, int Year)
        {

            try
            {
                //find the required record to edit       6th row
                IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[6]/tr/td[6]/span[1]/i"));
                updateIcon.Click();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            EditEducation(UniversityName, Country, Degree, Title, Year);
        }
        public void RemoveEducation(string UniversityName, string Country, string Degree, string Title, int Year)
        {
            driver.FindElement(profileTab).Click();

            //find and click on education tab            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(educationTab).Click();

            ExtentReportManager.CreateTest("Deleting records to Education", "Containg Canada,B.Tech");
            ExtentReportManager.LogTestStep(Status.Info, "Running the test");


            try
            {
                IWebElement deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{Country}'] and td[text()='{Title}']]]//span[2]"));
                //IWebElement deleteIcon = driver.FindElement(By.XPath("//tbody[tr[td[text()='Canada'] and td[text()='B.Tech']]]//span[2]"));
                deleteIcon.Click();
                //check for message that new Education is deleted successfully
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                string actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);
                string expectedMessage1 = "Education entry successfully removed";
                if (actualMessage == expectedMessage1)
                {
                    //click on cancel button

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

            //find and click on education tab            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(educationTab).Click();

            driver.FindElement(addNewButton).Click();
            driver.FindElement(cancelButton).Click();

            IWebElement updateIcon = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
            updateIcon.Click();
            IWebElement cancelUpdate = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            cancelUpdate.Click();

        }
    }

}