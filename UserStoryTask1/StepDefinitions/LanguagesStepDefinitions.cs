using InternshipTask1.Pages;
using InternshipTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace InternTask1.StepDefinitions
{
    [Binding]
    public class LanguagesStepDefinitions : CommonDriver
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

        }

        [Given(@"User is logged into localhost")]
        public void GivenUserIsLoggedInToLocalhost()
        {
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navigate to Go To Profile page")]
        public void WhenINavigateToGoToProfilePage()
        {
            ProfilePage profilepageobj = new ProfilePage();
            profilepageobj.GoToProfilePage(driver);
        }

        [When(@"I Add new '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAnd(string language, string level)
        {
            ProfilePage profilepageobj = new ProfilePage();
            profilepageobj.AddLanguage(driver, language, level);
        }

        [Then(@"New '([^']*)' and '([^']*)' are added successfully\.")]
        public void ThenNewAndAreAddedSuccessfully_(string Language, string Level)
        {

            ProfilePage profilepageobj = new ProfilePage();

            (string firstLanguage, string firstLevel) = profilepageobj.VerifyAddLanguage(driver);

            Assert.AreEqual(Language, firstLanguage, "Input language and added first langauage do not match");
            Assert.AreEqual(Level, firstLevel, "Input level and added first level do not match");

        }


        [When(@"I navigate to Language tab on Profile page")]
        public void WhenINavigateToProfilePage()
        {
            ProfilePage profiletabobj = new ProfilePage();
            profiletabobj.ClickOnProfileTab(driver);

        }

        [When(@"I Edit existing '([^']*)' and '([^']*)'")]
        public void WhenIEditExistingAnd(string language, string level)
        {
            ProfilePage editlanguageobj = new ProfilePage();
            editlanguageobj.EditLanguageAndLevel(driver, language, level);
        }


        [Then(@"New '([^']*)' and '([^']*)' are edited successfully\.")]
        public void ThenNewAndAreEditedSuccessfully_(string Language, string Level)
        {
            ProfilePage profilepageobj = new ProfilePage();

            (string firstLanguage, string firstLevel) = profilepageobj.VerifyAddLanguage(driver);

            Assert.AreEqual(Language, firstLanguage, "Input language and edited first langauage do not match");
            Assert.AreEqual(Level, firstLevel, "Input level and edited first level do not match");
        }

        [When(@"I delete existing record\.")]
        public void WhenIDeleteExistingRecord_()
        {
            ProfilePage cancelFunction = new ProfilePage();
            cancelFunction.checkCancelFunction(driver);

            ProfilePage deletelanguageobj = new ProfilePage();
            deletelanguageobj.DeleteLanguageAndLevel(driver);
        }

        [Then(@"Existing record deleted successfully\.")]
        public void ThenExistingRecordDeletedSuccessfully_()
        {
            Console.WriteLine("Delete fuctionality checked successfully");
        }



        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
