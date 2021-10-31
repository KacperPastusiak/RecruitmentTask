using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using System.Collections.Generic;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestStudentLanguageGroupRule
    {
        private readonly static List<string> languageGroups = new List<string> { "PL", "EN" };

        [TestMethod]
        public void NullProperties()
        {
            var rule = new StudentLanguageGroupRule(null, null);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        public void NullLanguageGroup()
        {
            var rule = new StudentLanguageGroupRule(null, new List<string>());

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        public void NullLanguageGroups()
        {
            var rule = new StudentLanguageGroupRule("aa", null);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("pl")]
        [DataRow("Pl")]
        [DataRow("pL")]
        [DataRow("en")]
        [DataRow("En")]
        [DataRow("eN")]
        public void CaseSensitivity(string language)
        {
            var rule = new StudentLanguageGroupRule(language, languageGroups);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("PL")]
        [DataRow("EN")]
        public void CorrectLanguage(string language)
        {
            var rule = new StudentLanguageGroupRule(language, languageGroups);

            Assert.IsFalse(rule.IsBroken());
        }
    }
}
