using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestLastNameRule
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void NotValid(string name)
        {
            var rule = new LastNameRule(name);

            Assert.IsTrue(rule.IsBroken());
        }

        [TestMethod]
        [DataRow("aaa")]
        [DataRow("Aaa")]
        [DataRow("AAA")]
        public void Valid(string name)
        {
            var rule = new LastNameRule(name);

            Assert.IsFalse(rule.IsBroken());
        }
    }
}
