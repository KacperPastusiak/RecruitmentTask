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
        /// Class identifier.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Class group.
        /// </summary>
        public char Group { get; set; }

        /// <summary>
        /// Langruage groups.
        /// </summary>
        public List<string> LanguageGroups { get; set; }

        /// <summary>
        /// Tutor.
        /// </summary>
        public Tutor Tutor { get; set; }

        /// <summary>
        /// List of students.
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        /// Create a new instance of a <see cref="SchoolClass"/>.
        /// </summary>
        private SchoolClass() { }

        public static SchoolClass CreateSchoolClass(char group,
                                                    List<string> languageGroups)
        {
            CheckRule(new TwoLanguageGroupPerSchoolClassRule(languageGroups));

            return new SchoolClass()
            {
                ID = Guid.NewGuid(),
                Group = group,
                LanguageGroups = languageGroups
            };
        }
    }
}
