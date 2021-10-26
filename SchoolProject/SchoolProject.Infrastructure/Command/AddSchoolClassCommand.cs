using MediatR;
using System;
using System.Collections.Generic;

namespace SchoolProject.Infrastructure.Command
{
    public class AddSchoolClassCommand : IRequest<Guid>
    {
        public char Group { get; set; }
        public List<string> LanguageGroups { get; set; }

        public AddSchoolClassCommand(char group,
                                     List<string> languageGroups)
        {
            Group = group;
            LanguageGroups = languageGroups;
        }
    }
}
