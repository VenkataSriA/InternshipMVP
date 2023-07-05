using InternshipTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InternshipTask1.Pages
{
    public class ProfilePage : CommonDriver
    {

        private IWebElement addNewButton => driver.FindElement(By.XPath("//thead/tr/th[3]/div[@class='ui teal button ']"));
        By addLanguage = By.XPath("//div[@class='five wide field']/input");
        By addButton = By.XPath("//div[@class='six wide field']/input[1]");
        By profileTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        By languageTab = By.XPath("//a[@class= 'item active']");
        By editButton = By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        By cancelButton = By.XPath("//input[@value= 'Cancel']");
        public void GoToProfilePage(IWebDriver driver)
        {

            // go to hi user dropdown
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 5);
            IWebElement userDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            userDropdown.Click();

            // select go to profile from drop down            
            IWebElement profileOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]", 7);
            profileOption.Click();

            //or click on profile tab
        }


        public void AddLanguage(IWebDriver driver, string Language, string Level)
        {


            //find lang tab
            driver.FindElement(languageTab).Click();


            Wait.WaitToBeClickable(driver, "XPath", "//thead/tr/th[3]/div[@class='ui teal button ']", 3);
            addNewButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='five wide field']/input", 5);

            driver.FindElement(addLanguage).Click();
            driver.FindElement(addLanguage).SendKeys(Language);


            IWebElement chooseLanguageLevel = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement languageLevel = new SelectElement(chooseLanguageLevel);

            languageLevel.SelectByText(Level); // selects based on text in dropdown            

            driver.FindElement(addButton).Click();

            //check for message that new language is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text
            string expectedMessage = Language + " has been added to your languages";
            Assert.AreEqual(expectedMessage, actualMessage, "The language and level already exist");

            // if (expectedMessage == actualMessage)
            //{
            //    Console.WriteLine("New language and level added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("The language and level already exist");
            //    //close the message
            //    //click on cancel
            //    By cancelButton = By.XPath("//div[2]/div/div[2]/div/div/div[3]/input[2]");
            //    driver.FindElement(cancelButton).Click();

            //}

        }

        public (string, string) VerifyAddLanguage(IWebDriver driver)
        {


            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);           
            //driver.FindElement(profileTab).Click();

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement firstLanguage = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 7);
            IWebElement firstLevel = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            return (firstLanguage.Text, firstLevel.Text);


        }

        public void ClickOnProfileTab(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTab).Click();

        }

        public void EditLanguageAndLevel(IWebDriver driver, string Language, string Level)
        {
            driver.FindElement(languageTab).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 3);
            driver.FindElement(editButton).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='five wide field']/input", 5);
            driver.FindElement(addLanguage).Clear();
            driver.FindElement(addLanguage).SendKeys(Language);

            IWebElement chooseLanguageLevel = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement languageLevel = new SelectElement(chooseLanguageLevel);
            languageLevel.SelectByText(Level); // selects based on text in dropdown

            Thread.Sleep(1000);
            By updateButton = By.XPath("//*[contains(@value, 'Update')]");
            driver.FindElement(updateButton).Click();

            //check for message that new language is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text
            string expectedMessage = Language + " has been updated to your languages";
            Assert.AreEqual(expectedMessage, actualMessage, "Error while editing the language.");



        }

        public void DeleteLanguageAndLevel(IWebDriver driver)
        {
            driver.FindElement(languageTab).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i", 3);
            By deleteButton = By.XPath("//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i");
            driver.FindElement(deleteButton).Click();



            //check for message that new language is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);
            // Verify the expected message text


        }

        public void checkCancelFunction(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 3);
            driver.FindElement(editButton).Click();
            driver.FindElement(cancelButton).Click();
            Console.WriteLine("Cancel function checked for Edit");

            Wait.WaitToBeClickable(driver, "XPath", "//thead/tr/th[3]/div[@class='ui teal button ']", 3);
            addNewButton.Click();
            driver.FindElement(cancelButton).Click();
            Console.WriteLine("Cancel function checked for AddNew");
        }


    }


}
