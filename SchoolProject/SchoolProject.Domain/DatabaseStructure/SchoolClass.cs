using SchoolProject.Domain.BusinessRule;
using System;
using System.Collections.Generic;

namespace SchoolProject.Domain.DatabaseStructure
{
    /// <summary>
    /// Represents school class database structure.
    /// </summary>
    public class SchoolClass : AEntity
    {
        /// <summary>
        /// School class identifier.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// School class group.
        /// </summary>
        public char Group { get; private set; }

        /// <summary>
        /// Language groups.
        /// </summary>
        public List<string> LanguageGroups { get; private set; }

        /// <summary>
        /// Tutor.
        /// </summary>
        public Tutor Tutor { get; private set; }

        /// <summary>
        /// List of students.
        /// </summary>
        public List<Student> Students { get; private set; }

        private SchoolClass() { }

        /// <summary>
        /// Create a new instance of a class <see cref="SchoolClass"/>.
        /// </summary>
        /// <param name="group">Class group.</param>
        /// <param name="languageGroups">Class language groups.</param>
        /// <returns>New instance of a class <see cref="SchoolClass"/>.</returns>
        public static SchoolClass CreateSchoolClass(char group,
                                                    List<string> languageGroups)
        {
            CheckRule(new AtLeastOneLanguageGroupRule(languageGroups));
            CheckRule(new TwoLanguageGroupPerSchoolClassRule(languageGroups));

            foreach (var languageGroup in languageGroups)
            {
                CheckRule(new SupportedLanguageGroupRule(languageGroup));
            }

            return new SchoolClass()
            {
                ID = Guid.NewGuid(),
                Group = group,
                LanguageGroups = languageGroups
            };
        }
    }
}
