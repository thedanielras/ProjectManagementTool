using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class ProjectsListViewModel
    {
        public ProjectsListViewModel(IEnumerable<Project>  projects)
        {
            this.Projects = projects;
        }

        public IEnumerable<Project> Projects { get; set; }
    }
}
