using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Dtos;

namespace WebUI.MapperProfiles
{
    public class ProjectProfile : Profile
	{

        public ProjectProfile()
        {
			CreateMap<User, UserDto>();
			CreateMap<ProjectSource, ProjectSourceDto>();
			CreateMap<Department, DepartmentDto>();
			CreateMap<Project, ProjectDto>();
		}		
	}
}
