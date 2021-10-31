using MediatR;
using System;
using System.Collections.Generic;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represents add school class command.
    /// </summary>
    public class AddSchoolClassCommand : IRequest<Guid>
    {
        /// <summary>
        /// School class group.
        /// </summary>
        public char Group { get; private set; }

        /// <summary>
        /// School class language group.
        /// </summary>
        public List<string> LanguageGroups { get; private set; }

        /// <summary>
        /// Create a new instance of a class <see cref="AddStudentCommand"/>.
        /// </summary>
        /// <param name="group">School class group.</param>
        /// <param name="languageGroups">School class language group.</param>
        public AddSchoolClassCommand(char group,
                                     List<string> languageGroups)
        {
            Group = group;
            LanguageGroups = languageGroups;
        }
    }
}
