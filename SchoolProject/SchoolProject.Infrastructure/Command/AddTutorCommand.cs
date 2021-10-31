using MediatR;
using System;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represents add tutor command.
    /// </summary>
    public class AddTutorCommand : IRequest<Guid>
    {
        /// <summary>
        /// Tutor name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Tutor last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Tutor school class identifier.
        /// </summary>
        public Guid SchoolClassId { get; private set; }

        /// <summary>
        /// Create a new instance of a class <see cref="AddTutorCommand"/>.
        /// </summary>
        /// <param name="name">Tutor name.</param>
        /// <param name="lastName">Tutor last name.</param>
        /// <param name="schoolClassId">School class identifier.</param>
        public AddTutorCommand(string name, string lastName, Guid schoolClassId)
        {
            Name = name;
            LastName = lastName;
            SchoolClassId = schoolClassId;
        }
    }
}
