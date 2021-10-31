using SchoolProject.Domain.BusinessRule;
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
        public Guid ID { get; private set; }

        /// <summary>
        /// Tutor name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Tutor last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// School class identifier <see cref="SchoolClass.Id"/>.
        /// </summary>
        public Guid SchoolClassId { get; private set; }

        /// <summary>
        /// School class <see cref="SchoolClass"/>.
        /// </summary>
        public SchoolClass SchoolClass { get; private set; }

        private Tutor() { }

        /// <summary>
        /// Create a new instance of a class <see cref="Tutor"/>.
        /// </summary>
        /// <param name="name">Tutor name.</param>
        /// <param name="lastName">Tutor last name.</param>
        /// <param name="schoolClass">School class to which the tutor belongs.</param>
        /// <returns>New instance of a class <see cref="Tutor"/>.</returns>
        public static Tutor CreateTutor(string name, string lastName, SchoolClass schoolClass)
        {
            CheckRule(new NameRule(name));
            CheckRule(new LastNameRule(lastName));

            if (schoolClass.Tutor != null)
                CheckRule(new OneTutorPerSchoolClassRule(schoolClass.Tutor.ID));

            return new Tutor()
            {
                ID = Guid.NewGuid(),
                Name = name,
                LastName = lastName,
                SchoolClassId = schoolClass.ID
            };
        }
    }
}
