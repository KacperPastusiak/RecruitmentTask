using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using System.Collections.Generic;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestTwoLanguageGroupPerSchoolClassRule
    {
        [TestMethod]
        public void NullLanguageGroups()
        {
            var rule = new TwoLanguageGroupPerSchoolClassRule(null);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        public void Empty()
        {
            var rule = new TwoLanguageGroupPerSchoolClassRule(new List<string>());

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void OneElement()
        {
            var rule = new TwoLanguageGroupPerSchoolClassRule(new List<string>() { "one" });

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void TwoElements()
        {
            var rule = new TwoLanguageGroupPerSchoolClassRule(new List<string>() { "one", "two" });

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void ThreeElements()
        {
            var rule = new TwoLanguageGroupPerSchoolClassRule(new List<string>() { "one", "two", "three" });

            Assert.IsTrue(rule.IsBroken());
        }
    }
}
