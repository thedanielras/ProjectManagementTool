using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Dtos;

namespace WebUI.ViewModels
{
    public class ProjectsListViewModel
    {
        public ProjectsListViewModel(IEnumerable<ProjectDto>  projects)
        {
            this.Projects = projects;
        }

        public IEnumerable<ProjectDto> Projects { get; set; }
    }
}
