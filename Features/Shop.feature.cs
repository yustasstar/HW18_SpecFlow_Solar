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
namespace HW18_SpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ShopPage")]
    [NUnit.Framework.CategoryAttribute("ShopPageSetup")]
    public partial class ShopPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "ShopPageSetup"};
        
#line 1 "Shop.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ShopPage", "As a User, I want to group products into tabs,\r\nI can filter products by values o" +
                    "n those tabs,\r\nI can add items to the cart, \r\nand remove added items from the ca" +
                    "rt.", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Verify every Tab <h1>:")]
        [NUnit.Framework.TestCaseAttribute("Сонячні панелі", "Сонячні панелі", null)]
        [NUnit.Framework.TestCaseAttribute("Інвертори", "Сонячні інвертори", null)]
        [NUnit.Framework.TestCaseAttribute("Акумулятори", "Акумулятори", null)]
        [NUnit.Framework.TestCaseAttribute("Контролери заряду", "Контролери заряду", null)]
        [NUnit.Framework.TestCaseAttribute("Системи кріплення", "Системи кріплення", null)]
        [NUnit.Framework.TestCaseAttribute("Кабель і комутація", "Сонячний кабель", null)]
        public void VerifyEveryTabH1(string tabName, string h1, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Tab Name", tabName);
            argumentsOfScenario.Add("h1", h1);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify every Tab <h1>:", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
 testRunner.Given("I am on \'shop\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
 testRunner.When(string.Format("I click on \'{0}\' tab", tabName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
 testRunner.Then(string.Format("I see \'{0}\' heading is displayed", h1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Filter:")]
        [NUnit.Framework.TestCaseAttribute("inverters", "Huawei", null)]
        [NUnit.Framework.TestCaseAttribute("inverters", "Deye", null)]
        [NUnit.Framework.TestCaseAttribute("inverters", "Fronius", null)]
        [NUnit.Framework.TestCaseAttribute("inverters", "LuxPower", null)]
        [NUnit.Framework.TestCaseAttribute("inverters", "Victron Energy", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "SOLA", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "Abi-Solar", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "Ulica Solar", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "Yingli Solar", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "JA Solar", null)]
        [NUnit.Framework.TestCaseAttribute("solar-panels", "Jinko Solar", null)]
        [NUnit.Framework.TestCaseAttribute("batteries", "AXIOMA", null)]
        [NUnit.Framework.TestCaseAttribute("batteries", "BYD", null)]
        [NUnit.Framework.TestCaseAttribute("batteries", "PYLONTECH", null)]
        public void VerifyFilter(string tab, string filterValue, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Tab", tab);
            argumentsOfScenario.Add("FilterValue", filterValue);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Filter:", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
 testRunner.Given(string.Format("I am on \'shop/{0}\' page", tab), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 33
 testRunner.When("I click on Filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 34
 testRunner.And(string.Format("I click on \'{0}\' checkbox", filterValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then(string.Format("I see \'{0}\' products", filterValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add/Remove product in Cart:")]
        [NUnit.Framework.TestCaseAttribute("Huawei SUN2000-50KTL-M3", "PYLONTECH US5000", null)]
        [NUnit.Framework.TestCaseAttribute("Deye SUN-12K-SG04LP3-EU", "Huawei SUN2000-10KTL-M1", null)]
        public void AddRemoveProductInCart(string firstProduct, string secondProduct, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("First product", firstProduct);
            argumentsOfScenario.Add("Second product", secondProduct);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add/Remove product in Cart:", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 60
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 62
 testRunner.Given("I am on \'shop\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 64
 testRunner.When(string.Format("I add \'{0}\' to the Cart", firstProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 65
 testRunner.And("I click \'Продовжити купувати\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.And(string.Format("I add \'{0}\' to the Cart", secondProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("I click \'Оформити замовлення\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.Then("I am on the \'cart\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 70
 testRunner.And("I see heading \'Товари у кошику\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.And(string.Format("I see \'{0}\' in the Cart", firstProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And(string.Format("I see \'{0}\' in the Cart", secondProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
    testRunner.When(string.Format("I remove \'{0}\' from the Cart", firstProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 76
    testRunner.Then(string.Format("I do not see \'{0}\' in the Cart", firstProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 77
 testRunner.And(string.Format("I see \'{0}\' in the Cart", secondProduct), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
