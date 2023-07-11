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
    [NUnit.Framework.DescriptionAttribute("Languages")]
    public partial class LanguagesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Languages.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Languages", "Use case:\r\nAs a user I would be able to show what languages and skills I know.\r\nS" +
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
        [NUnit.Framework.DescriptionAttribute("[1] Add details to languages tab.")]
        [NUnit.Framework.CategoryAttribute("mytag1")]
        [NUnit.Framework.TestCaseAttribute("English", "Basic", null)]
        [NUnit.Framework.TestCaseAttribute("", "Choose Language Level", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Basic", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Conversational", null)]
        [NUnit.Framework.TestCaseAttribute("english", "Basic", null)]
        [NUnit.Framework.TestCaseAttribute("French", "Choose Language Level", null)]
        [NUnit.Framework.TestCaseAttribute("", "Basic", null)]
        [NUnit.Framework.TestCaseAttribute("!@34", "Fluent", null)]
        [NUnit.Framework.TestCaseAttribute("\" \"", "Native/Bilingual", null)]
        [NUnit.Framework.TestCaseAttribute("German", "Basic", null)]
        public void _1AddDetailsToLanguagesTab_(string language, string level, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Language", language);
            argumentsOfScenario.Add("Level", level);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[1] Add details to languages tab.", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.When("I navigate to Go To Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.And(string.Format("I Add new \'{0}\' and \'{1}\'", language, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then(string.Format("New \'{0}\' and \'{1}\' are added successfully.", language, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[2] Edit details of added languages tab.")]
        [NUnit.Framework.CategoryAttribute("mytag2")]
        [NUnit.Framework.TestCaseAttribute("Spanish", "Conversational", null)]
        [NUnit.Framework.TestCaseAttribute("", "Fluent", null)]
        [NUnit.Framework.TestCaseAttribute("German", "Language Level", null)]
        [NUnit.Framework.TestCaseAttribute("English", "Native/Bilingual", null)]
        public void _2EditDetailsOfAddedLanguagesTab_(string language, string level, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag2"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Language", language);
            argumentsOfScenario.Add("Level", level);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[2] Edit details of added languages tab.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 29
 testRunner.Given("User is logged into localhost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 30
 testRunner.When("I navigate to Language tab on Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
 testRunner.And(string.Format("I Edit existing \'{0}\' and \'{1}\'", language, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.Then(string.Format("New \'{0}\' and \'{1}\' are edited successfully.", language, level), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[3] Delete details of added languages.")]
        [NUnit.Framework.CategoryAttribute("mytag3")]
        public void _3DeleteDetailsOfAddedLanguages_()
        {
            string[] tagsOfScenario = new string[] {
                    "mytag3"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[3] Delete details of added languages.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 43
 testRunner.Given("User is logged into localhost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 44
 testRunner.When("I navigate to Language tab on Profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 45
 testRunner.And("I delete existing record.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
 testRunner.Then("Existing record deleted successfully.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
