using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Domain.BusinessRule;
using SchoolProject.Domain.DatabaseStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Test.SchoolProject.Domain.DatabaseStructure
{
    [TestClass]
    public class TestTutor
    {
        private static SchoolClass schoolClass;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            schoolClass = SchoolClass.CreateSchoolClass('A', new List<string> { "PL" });
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void CreateTutor_Name_NotValid(string name)
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = Tutor.CreateTutor(name, "Last name", schoolClass);
            }, typeof(NameRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void CreateTutor_LastName_NotValid(string lastName)
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = Tutor.CreateTutor("Name", lastName, schoolClass);
            }, typeof(LastNameRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Name", "Last name")]
        public void CreateTutor_Valid(string name, string lastName)
        {
            var actual = Tutor.CreateTutor(name, lastName, schoolClass);

            Assert.AreNotEqual(Guid.Empty, actual.ID);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(lastName, actual.LastName);
            Assert.AreEqual(schoolClass.ID, actual.SchoolClassId);
        }
    }
}
