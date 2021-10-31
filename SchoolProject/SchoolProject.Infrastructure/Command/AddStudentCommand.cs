using MediatR;
using SchoolProject.Common.Enums;
using System;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represents add student command.
    /// </summary>
    public class AddStudentCommand : IRequest<Guid>
    {
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
        /// Student language group.
        /// </summary>
        public string LanguageGroup { get; private set; }

        /// <summary>
        /// School class identifier.
        /// </summary>
        public Guid SchoolClassId { get; private set; }

        /// <summary>
        /// Create a new instance of a class <see cref="AddStudentCommand"/>.
        /// </summary>
        /// <param name="name">Student name.</param>
        /// <param name="lastName">Student last name.</param>
        /// <param name="gender">Student gender.</param>
        /// <param name="languageGroup">Student language group.</param>
        /// <param name="schoolClassId">School class identifier.</param>
        public AddStudentCommand(string name, string lastName, EGender gender, string languageGroup, Guid schoolClassId)
        {
            Name = name;
            LastName = lastName;
            Gender = gender;
            LanguageGroup = languageGroup;
            SchoolClassId = schoolClassId;
        }
    }
}
