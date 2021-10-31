using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using System.Collections.Generic;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestAtLeastOneLanguageGroupRule
    {
        [TestMethod]
        public void NullLanguageGroups()
        {
            var rule = new AtLeastOneLanguageGroupRule(null);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        public void Empty()
        {
            var rule = new AtLeastOneLanguageGroupRule(new List<string>());

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        public void OneElement()
        {
            var rule = new AtLeastOneLanguageGroupRule(new List<string>() { "one" });

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void TwoElements()
        {
            var rule = new AtLeastOneLanguageGroupRule(new List<string>() { "one", "two" });

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void ThreeElements()
        {
            var rule = new AtLeastOneLanguageGroupRule(new List<string>() { "one", "two", "three" });

            Assert.IsFalse(rule.IsBroken());
        }
    }
}
