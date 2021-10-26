using SchoolProject.Common.Enums;
using System;

namespace SchoolProject.Domain.DatabaseStructure
{
    /// <summary>
    /// Represents Student database structure.
    /// </summary>
    public class Student : AEntity
    {
        /// <summary>
        /// Student identifier.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents student gender.
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// Language group.
        /// </summary>
        public string LanguageGroup { get; set; }

        /// <summary>
        /// School class identifier <see cref="SchoolClass.Id"/>.
        /// </summary>
        public Guid SchoolClassId { get; set; }

        /// <summary>
        /// School class <see cref="SchoolClass"/>.
        /// </summary>
        public SchoolClass SchoolClass { get; set; }
    }
}
