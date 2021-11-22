using Application.Common.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult List()
        {
            var projects = _projectRepository.AllProjects;
            var projectsListViewModel = new ProjectsListViewModel(projects);

            return View(projectsListViewModel);
        }
    }
}
