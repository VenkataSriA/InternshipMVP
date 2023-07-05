using InternshipTask1.Pages;
using InternshipTask1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStoryTask1.Pages
{
    public class SkillsPage: CommonDriver
    {
        By profileTabButton = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        public void ProfileTab(IWebDriver driver)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTabButton).Click();
        }


    }
}
