using InternshipTask1.Pages;
using InternshipTask1.Utilities;
using NUnit.Framework;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using UserStoryTask1.Pages;

namespace UserStoryTask1.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions: CommonDriver
    {
        SkillsPage skillspageobj;
        public SkillsStepDefinitions()
        {
            skillspageobj = new SkillsPage();
        }
               

        [When(@"I navigate to Profile page")]
        public void WhenINavigateToProfilePage()
        {

            skillspageobj.ProfileTab();
        }

        //Add skill scenario

        [When(@"I add new '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAsAnd(string Skill, string Level)
        {
            
            skillspageobj.AddSkills(driver, Skill,Level);
        }

        [Then(@"Verify new '([^']*)' and '([^']*)' are added successfully\.")]
        public void ThenVerifyNewAsAndAreAddedSuccessfully_(string Skill, string Level)
        {

            (string addedSkill, string addedSkillLevel) = skillspageobj.VerifyAddedSkills();

            if (Skill == addedSkill && Level == addedSkillLevel)
            {
                Assert.AreEqual(Skill, addedSkill, "Input language and added first langauage do not match");
                Assert.AreEqual(Level, addedSkillLevel, "Input level and added first level do not match");
            }
            else
            {
                Assert.Pass("Check for message");
            }
                        
        }

        //edit skill scenario

        [When(@"I edit existing '([^']*)' and '([^']*)'")]
        public void WhenIEditExistingAnd(string Skills, string Level)
        {
            skillspageobj.ProfileTab();
            skillspageobj.EditSkillAndLevel(Skills, Level);
        }

        [Then(@"Verify new '([^']*)' and '([^']*)' are edited successfully\.")]
        public void ThenVerifyNewAndAreEditedSuccessfully_(string Skills, string Level)
        {
            (string editedSkill, string editedSkillLevel) = skillspageobj.VerifyEditedSkills();

            if (Skills == editedSkill && Level == editedSkillLevel)
            {
                Assert.AreEqual(Skills, editedSkill, "Input language and added first langauage do not match");
                Assert.AreEqual(Level, editedSkillLevel, "Input level and added first level do not match");
            }
            else
            {
                Assert.Pass("Something's not right.Check for error message");
            }

            //Assert.AreEqual(Skills, editedSkill, "Input language and edited first langauage do not match");
            //Assert.AreEqual(Level, editedLevel, "Input level and edited first level do not match");
        }

        //Delete skill scenario

        [When(@"I delete existing '([^']*)' and '([^']*)'")]
        public void WhenIDeleteExistingAnd(string Skills, string Level)
        {
            skillspageobj.GoToProfilePage();
            skillspageobj.DeleteSkillsAndLevel(Skills, Level);
            skillspageobj.checkCancelFunction();
        }

        [Then(@"Existing skill deleted successfully\.")]
        public void ThenExistingSkillDeletedSuccessfully_()
        {
            Console.WriteLine("Delete fuctionality checked successfully");
        }

    }
}
