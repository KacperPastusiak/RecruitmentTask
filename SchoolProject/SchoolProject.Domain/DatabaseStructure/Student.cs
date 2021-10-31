using SchoolProject.Common.Enums;
using SchoolProject.Domain.BusinessRule;
using System;

namespace SchoolProject.Domain.DatabaseStructure
{
    /// <summary>
    /// Represents student database structure.
    /// </summary>
    public class Student : AEntity
    {
        /// <summary>
        /// Student identifier.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Student last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Student gender.
        /// </summary>
        public EGender Gender { get; private set; }

        /// <summary>
        /// Language group.
        /// </summary>
        public string LanguageGroup { get; private set; }

        /// <summary>
        /// School class identifier <see cref="SchoolClass.Id"/>.
        /// </summary>
        public Guid SchoolClassId { get; private set; }

        /// <summary>
        /// School class.
        /// </summary>
        public SchoolClass SchoolClass { get; private set; }

        private Student() { }

        /// <summary>
        /// Create a new instance of a class <see cref="Student"/>.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="lastName">Student last name.</param>
        /// <param name="gender">Student gender.</param>
        /// <param name="languageGroup">Student language group.</param>
        /// <param name="schoolClass">School class to which the student belongs.</param>
        /// <returns>New instance of a class <see cref="Student"/>.</returns>
        public static Student CreateStudent(string name, string lastName, EGender gender, string languageGroup, SchoolClass schoolClass)
        {
            CheckRule(new NameRule(name));
            CheckRule(new LastNameRule(lastName));
            CheckRule(new StudentLanguageGroupRule(languageGroup, schoolClass?.LanguageGroups));

            return new Student
            {
                ID = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                Gender = gender,
                LanguageGroup = languageGroup,
                SchoolClassId = schoolClass.ID
            };
        }
    }
}
