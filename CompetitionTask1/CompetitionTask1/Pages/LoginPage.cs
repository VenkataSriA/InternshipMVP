using ConsoleApp2.Utilities;
using OpenQA.Selenium;

namespace ConsoleApp2.Pages
{
    public class LoginPage : CommonDriver
    {
        IWebElement signIn => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        IWebElement username => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        IWebElement password => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        IWebElement loginbutton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        IWebElement hiUser => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        public void LoginSteps()
        {
            //click on signin button            
            signIn.Click();

            // enter username in textbox            
            username.SendKeys("ashashank217@gmail.com");

            // enter password
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[2]/input", 7);

            password.SendKeys("SydneyQa2018");

            // click on login
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]/button", 7);
            loginbutton.Click();

            //Validate if user logged in or not
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 5);

            if (hiUser.Text == "Hi Venkata")
            {
                Console.WriteLine("User authentication pass");
            }
            else { Console.WriteLine("User authentication failed."); }
            //Assert.AreEqual(hiUser.Text, "Hi Venkata");

        }

    }






}
