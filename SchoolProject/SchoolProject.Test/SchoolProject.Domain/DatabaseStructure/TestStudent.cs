using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolProject.Common.Enums;
using SchoolProject.Domain.BusinessRule;
using SchoolProject.Domain.DatabaseStructure;
using System;
using System.Collections.Generic;

namespace SchoolProject.Test.SchoolProject.Domain.DatabaseStructure
{
    [TestClass]
    public class TestStudent
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
        public void CreateStudent_Name_NotValid(string name)
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = Student.CreateStudent(name, "Last name", EGender.Male, "PL", schoolClass);
            }, typeof(NameRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void CreateStudent_LastName_NotValid(string lastName)
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = Student.CreateStudent("Name", lastName, EGender.Male, "PL", schoolClass);
            }, typeof(LastNameRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        // empty
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        // case sensitivity
        [DataRow("pl")]
        [DataRow("Pl")]
        [DataRow("pL")]
        // wrong language group
        [DataRow("EN")]
        [DataRow("FR")]
        [DataRow("RU")]
        public void CreateStudent_LanguageGroup_NotValid(string language)
        {
            var result = RuleCheckerHelper.CheckBusinessRuleException(() =>
            {
                _ = Student.CreateStudent("Name", "Last name", EGender.Male, language, schoolClass);
            }, typeof(StudentLanguageGroupRule));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Name", "LastName", EGender.Male, "PL")]
        [DataRow("Name", "LastName", EGender.Female, "PL")]
        public void CreateStudent_Valid(string name, string lastName, EGender gender, string language)
        {
            var actual = Student.CreateStudent(name, lastName, gender, language, schoolClass);

            Assert.AreNotEqual(Guid.Empty, actual.ID);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(lastName, actual.LastName);
            Assert.AreEqual(gender, actual.Gender);
            Assert.AreEqual(language, actual.LanguageGroup);
            Assert.AreEqual(schoolClass.ID, actual.SchoolClassId);
        }
    }
}
