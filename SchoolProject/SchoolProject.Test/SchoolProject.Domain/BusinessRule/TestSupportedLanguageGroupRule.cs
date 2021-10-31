using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestSupportedLanguageGroupRule
    {
        [TestMethod]
        public void NullLanguage()
        {
            var rule = new SupportedLanguageGroupRule(null);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("ABCD")]
        [DataRow("abcd")]
        [DataRow("AbCd")]
        public void NotLanguage(string language)
        {
            var rule = new SupportedLanguageGroupRule(language);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("en")]
        [DataRow("pl")]
        [DataRow("fr")]
        [DataRow("ru")]
        public void CorrectLanguageLowerCase(string language)
        {
            var rule = new SupportedLanguageGroupRule(language);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("En")]
        [DataRow("eN")]
        [DataRow("Pl")]
        [DataRow("pL")]
        [DataRow("Fr")]
        [DataRow("fR")]
        [DataRow("Ru")]
        [DataRow("rU")]
        public void CorrectLanguageRandomCase(string language)
        {
            var rule = new SupportedLanguageGroupRule(language);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("EN")]
        [DataRow("PL")]
        [DataRow("FR")]
        [DataRow("RU")]
        public void CorrectLanguageUpperCase(string language)
        {
            var rule = new SupportedLanguageGroupRule(language);

            Assert.IsFalse(rule.IsBroken());
        }
    }
}
