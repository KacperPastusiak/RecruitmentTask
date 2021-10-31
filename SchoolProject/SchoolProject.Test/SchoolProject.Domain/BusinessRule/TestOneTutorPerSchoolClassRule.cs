using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using System;

namespace SchoolProject.Test.SchoolProject.Domain.BusinessRule
{
    [TestClass]
    public class TestOneTutorPerSchoolClassRule
    {
        [TestMethod]
        public void EmptyGuid()
        {
            var rule = new OneTutorPerSchoolClassRule(Guid.Empty);

            Assert.IsFalse(rule.IsBroken());
        }

        [TestMethod]
        public void RandomGuid()
        {
            var rule = new OneTutorPerSchoolClassRule(Guid.NewGuid());

            Assert.IsTrue(rule.IsBroken());
        }
    }
}
