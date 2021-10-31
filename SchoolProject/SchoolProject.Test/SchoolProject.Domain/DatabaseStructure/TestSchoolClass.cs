using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using SchoolProject.Domain.DatabaseStructure;
using System;
using System.Collections.Generic;

namespace SchoolProject.Test.SchoolProject.Domain.DatabaseStructure
{
    [TestClass]
    public class TestSchoolClass
    {
        [TestMethod]
        public void CreateSchoolClass_NullParameters()
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = SchoolClass.CreateSchoolClass('A', null);
            }, typeof(AtLeastOneLanguageGroupRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSchoolClass_EmptyLanguageGroup()
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = SchoolClass.CreateSchoolClass('A', new List<string>());
            }, typeof(AtLeastOneLanguageGroupRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSchoolClass_TooManyLanguageGroup()
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = SchoolClass.CreateSchoolClass('A', new List<string>() { "one", "two", "three" });
            }, typeof(TwoLanguageGroupPerSchoolClassRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSchoolClass_NotSupportedLanguageGroup()
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = SchoolClass.CreateSchoolClass('A', new List<string>() { "one", "two" });
            }, typeof(SupportedLanguageGroupRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateSchoolClass_Valid()
        {
            var languageGroups = new List<string> { "PL" };

            var actual = SchoolClass.CreateSchoolClass('A', languageGroups);

            Assert.AreNotEqual(Guid.Empty, actual.ID);
            Assert.AreEqual('A', actual.Group);
            CollectionAssert.AreEqual(languageGroups, actual.LanguageGroups);
        }
    }
}
