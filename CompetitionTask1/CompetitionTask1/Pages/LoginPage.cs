using ConsoleApp2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Pages
{
    public class LoginPage: CommonDriver
    {
        
        public void LoginSteps()
        {
            //click on signin button
            IWebElement signIn = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signIn.Click();

            // enter username in textbox
            IWebElement username = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            username.SendKeys("ashashank217@gmail.com");

            // enter password
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[2]/input", 7);
            IWebElement password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            password.SendKeys("SydneyQa2018");

            // click on login
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]/button", 7);
            IWebElement loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginbutton.Click();



            //Validate if user logged in or not
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 5);
            IWebElement hiUser = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
            if(hiUser.Text == "Hi Venkata") 
            {
                Console.WriteLine("User authentication pass");
            }
            else { Console.WriteLine("User authentication failed."); }
            //Assert.AreEqual(hiUser.Text, "Hi Venkata");
            
            
        }
                
    }
 

          

    

}
