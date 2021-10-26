using System;

namespace SchoolProject.Domain.DatabaseStructure
{
    /// <summary>
    /// Represents tutor database structure.
    /// </summary>
    public class Tutor : AEntity
    {
        /// <summary>
        /// Tutor identifier.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Tutor name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tutor last name.
        /// </summary>
        public string LastName { get; set; }

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
