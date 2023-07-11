using InternshipTask1.Pages;
using InternshipTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace UserStoryTask1.Pages
{
    public class SkillsPage: CommonDriver
    {
        By profileTabButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        By skillsTab = By.XPath("//a[contains(text(), 'Skills')]");
        By skillAddNew = By.XPath("//form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        By skillAddCancelButton = By.XPath("//form/div[3]/div/div[2]/div/div/span/input[2]");
        By addSkillTextbox = By.XPath("//input[@name='name']");
        By skilllevel = By.XPath("//select[@name='level']");
        By addSkillButton = By.XPath("//input[@value='Add']");
        By editSkillButton = By.XPath("//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]");
        By skillEditCancelButton = By.XPath("//form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]");
                
        public void ProfileTab()
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTabButton).Click();
        }

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

            //or click on profile tab
        }

        public void AddSkills(IWebDriver driver, string Skill, string Level)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//a[contains(text(), 'Skills')]", 7);
            driver.FindElement(skillsTab).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 7);
            driver.FindElement(skillAddNew).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='name']", 7);
            driver.FindElement(addSkillTextbox).Click();
            driver.FindElement(addSkillTextbox).SendKeys(Skill);

            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='level']", 7);
            driver.FindElement(skilllevel).SendKeys(Level);

            driver.FindElement(addSkillButton).Click();

            //check for message that new Skill is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text            
            string expectedMessage1 = Skill + " has been added to your skills";
            string expectedMessage2 = "Please enter skill and experience level";
            string expectedMessage3 = "This skill is already exist in your skill list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
            //Assert.AreEqual(expectedMessage, actualMessage, "Check for error message");
        }

        public (string, string) VerifyAddedSkills()
        {

            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);           
            //driver.FindElement(profileTab).Click();

            Wait.WaitToBeVisible(driver, "XPath", "//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement addedSkill = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Wait.WaitToBeVisible(driver, "XPath", "//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 7);
            IWebElement addedSkillLevel = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            return (addedSkill.Text, addedSkillLevel.Text);

        }

        public void EditSkillAndLevel(string Skills, string Level)
        {
            driver.FindElement(skillsTab).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]", 3);
            driver.FindElement(editSkillButton).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='five wide field']/input", 5);
            driver.FindElement(addSkillTextbox).Clear();
            driver.FindElement(addSkillTextbox).SendKeys(Skills);

            Wait.WaitToBeClickable(driver, "XPath", "//select[@name='level']", 7);
            driver.FindElement(skilllevel).SendKeys(Level); ; // selects based on text in dropdown

            Wait.WaitToBeClickable(driver, "XPath", "//form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]", 5);
            By updateSkillButton = By.XPath("//form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
            driver.FindElement(updateSkillButton).Click();

            //check for message that new language is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text            
            string expectedMessage1 = Skills + " has been updated to your skills";
            string expectedMessage2 = "Please enter skill and experience level";
            string expectedMessage3 = "This skill is already added to your skill list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
            //Assert.AreEqual(expectedMessage, actualMessage, "Error while editing the skill.");

        }

        public (string, string) VerifyEditedSkills()

        {


            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTabButton).Click();

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 2);
            IWebElement editedSkill = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody/tr/td[2]", 7);
            IWebElement editedSkillLevel = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));

            return (editedSkill.Text, editedSkillLevel.Text);

            //Assert.That(addedLanguage, Is.EqualTo(Language), "Language is not added or doesnt exist");
            //Assert.That(addedLanguageLevel, Is.EqualTo(Level), "Level is not added or doesnt exsit");

        }

        //Use this method to find and delete a particular language and level
        public void DeleteSkillsAndLevel(string Skills, string Level)
        {
                        
            driver.FindElement(skillsTab).Click();

            // find the element in the table
            try
            {
                IWebElement findSkill = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{Skills}'] and td[text()='{Level}']]]"));

                if (findSkill != null)
                {
                    var deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{Skills}'] and td[text()='{Level}']]]//span[2]/i"));
                    // Find and click the delete icon in the row            
                    deleteIcon.Click();

                    //check for message that new language is added successfully
                    Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                    IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                    // Get the text of the message element
                    string actualMessage = messageBox.Text;
                    Console.WriteLine(actualMessage);
                    // Verify the expected message text
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The elements don't exist in the table");
            }
                      
                        
        }

            
        public void checkCancelFunction()
        {

            driver.FindElement(profileTabButton).Click();
            driver.FindElement(skillsTab).Click();

            //scroll down
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown);

            Wait.WaitToBeClickable(driver, "XPath", "//div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]", 3);

            //check cancel function for add
            Wait.WaitToBeClickable(driver, "XPath", "//form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 3);
            driver.FindElement(skillAddNew).Click();
            driver.FindElement(skillAddCancelButton).Click();
            Console.WriteLine("Cancel function checked for AddNew");

            //check cancel function for edit
            driver.FindElement(editSkillButton).Click();
            driver.FindElement(skillEditCancelButton).Click();
            Console.WriteLine("Cancel function checked for Edit");

           
        }

    }
}
