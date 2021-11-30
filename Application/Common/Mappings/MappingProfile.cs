using Application.Projects.Queries.GetAllProjects;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectBriefDto>();     
        }



    }
}
