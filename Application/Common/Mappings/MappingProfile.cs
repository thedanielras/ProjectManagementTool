using Application.Projects.Queries.GetAllProjects;
using Application.Projects.Queries.GetProjectDetails;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Common.Mappings
{
    internal class MappingProfile : Profile
    {
        //public MappingProfile()
        //{
        //    CreateMap<User, UserDto>();
        //    CreateMap<Department, DepartmentDto>();
        //    CreateMap<Project, ProjectBriefDto>();
        //    CreateMap<Project, ProjectDetailsDto>();



        //}

        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }



    }
}
