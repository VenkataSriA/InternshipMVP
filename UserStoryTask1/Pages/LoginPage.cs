using OpenQA.Selenium;

namespace InternshipTask1.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {

            //click on signin button
            IWebElement signIn = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signIn.Click();
            Thread.Sleep(1000);

            //Click on transition window

            // enter username in textbox
            IWebElement username = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            username.SendKeys("ashashank217@gmail.com");

            // enter password
            IWebElement password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            password.SendKeys("SydneyQa2018");

            // click on login
            IWebElement loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginbutton.Click();
            Thread.Sleep(1000);
        }
    }
}
