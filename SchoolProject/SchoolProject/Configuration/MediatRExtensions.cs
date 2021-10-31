using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Command;
using SchoolProject.Infrastructure.Query;
using System.Reflection;

namespace SchoolProject.API.Configuration
{
    internal static class MediatRExtensions
    {
        internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(getAssembliesList());

            return services;
        }

        private static Assembly[] getAssembliesList()
        {
            return new Assembly[]
            {
                typeof(AddSchoolClassCommand).Assembly,
                typeof(AddStudentCommand).Assembly,
                typeof(GetStudentsSortedByGenderQuery).Assembly
            };
        }
    }
}
