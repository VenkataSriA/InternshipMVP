﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UserStoryTask1.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Skills")]
    public partial class SkillsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Skills.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Skills", "Use case:\r\nAs a user I would be able to show what languages and skills I know.\r\nS" +
                    "o that the people seeking for skills and languages can look at what details I ho" +
                    "ld.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[1] Add details to skills tab.")]
        [NUnit.Framework.CategoryAttribute("mytag1")]
        [NUnit.Framework.TestCaseAttribute("", "Choose Skill Level", null)]
        [NUnit.Framework.TestCaseAttribute("", "Beginner", null)]
        [NUnit.Framework.TestCaseAttribute("QA", "", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "Intermediate", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "Intermediate", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "Expert", null)]
        [NUnit.Framework.TestCaseAttribute("tester", "Intermediate", null)]
        [NUnit.Framework.TestCaseAttribute("[!#$>?", "Beginner", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Expert", null)]
        public void _1AddDetailsToSkillsTab_(string skills, string level, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Skills", skills);
            argumentsOfScenario.Add("Level", level);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[1] Add details to skills tab.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
 testRunner.Given("User is logged into localhost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.When("I navigate to Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.And(string.Format("I add new \'{0}\' and \'{1}\'", skills, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then(string.Format("Verify new \'{0}\' and \'{1}\' are added successfully.", skills, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[2] Edit details of added languages tab.")]
        [NUnit.Framework.CategoryAttribute("mytag2")]
        [NUnit.Framework.TestCaseAttribute("Test Analyst", "Intermediate", null)]
        [NUnit.Framework.TestCaseAttribute("", "Choose Skill Level", null)]
        [NUnit.Framework.TestCaseAttribute("", "Beginner", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "Expert", null)]
        [NUnit.Framework.TestCaseAttribute("Tester", "Intermediate", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Expert", null)]
        public void _2EditDetailsOfAddedLanguagesTab_(string skills, string level, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag2"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Skills", skills);
            argumentsOfScenario.Add("Level", level);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[2] Edit details of added languages tab.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 28
 testRunner.Given("User is logged into localhost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 29
 testRunner.When("I navigate to Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
 testRunner.And(string.Format("I edit existing \'{0}\' and \'{1}\'", skills, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.Then(string.Format("Verify new \'{0}\' and \'{1}\' are edited successfully.", skills, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[3] Delete details of added languages.")]
        [NUnit.Framework.CategoryAttribute("mytag3")]
        [NUnit.Framework.TestCaseAttribute("tester", "Expert", null)]
        [NUnit.Framework.TestCaseAttribute("[!#$>?", "Beginner", null)]
        [NUnit.Framework.TestCaseAttribute("tester", "Intermediate", null)]
        public void _3DeleteDetailsOfAddedLanguages_(string skills, string level, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag3"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Skills", skills);
            argumentsOfScenario.Add("Level", level);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[3] Delete details of added languages.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 44
 testRunner.Given("User is logged into localhost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 45
 testRunner.When("I navigate to Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 46
 testRunner.And(string.Format("I delete existing \'{0}\' and \'{1}\'", skills, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.Then("Existing skill deleted successfully.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
