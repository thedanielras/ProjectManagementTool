using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Common.Interfaces;
using WebUI.Dtos;
using WebUI.Services;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IViewRenderService _viewRenderService;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper, IViewRenderService viewRenderService)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _viewRenderService = viewRenderService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var projects = _projectRepository.AllProjects.ToList();
            var projectsListViewModel = new ProjectsListViewModel(_mapper.Map<IEnumerable<ProjectDto>>(projects));

            return View(projectsListViewModel);
        }

        [HttpGet]
        public IActionResult JsonList()
        {
            ResponseViewModel returnModel;
            var projects = _projectRepository.AllProjects.ToList();

            if (projects.Count > 0)
            {
                var payload = new ProjectsListViewModel(_mapper.Map<IEnumerable<ProjectDto>>(projects));
                returnModel = new ResponseViewModel(payload);
            } else
            {
                returnModel = new ResponseViewModel(null, ResponseType.KO, "Elements not found");
            }

            return Json(returnModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProjectDetailViewModal(Guid id) 
        {
            var project = _projectRepository.AllProjects.Where(p => p.ProjectId == id).FirstOrDefault();
            ResponseViewModel returnModel;

            if (project != null)
            {
                var projectDto = _mapper.Map<ProjectDto>(project);

                string result = await _viewRenderService.RenderToStringAsync("Projects/_ProjectDetails", projectDto);

                returnModel = new ResponseViewModel(result);
            }
            else
            {
                returnModel = new ResponseViewModel(null, ResponseType.KO, "Project not found!");
            }

            return Json(returnModel);
        }

        [HttpGet]
        public async Task<IActionResult> NewProjectViewModal()
        {
            //var allDepartments = 


            //IEnumerable<SelectListItem> departmentSelectList = 


            //var viewModel = new AddProjectViewModel()

            ResponseViewModel returnModel;
            string result = await _viewRenderService.RenderToStringAsync("Projects/_AddProject", null);
            returnModel = new ResponseViewModel(result);
            return Json(returnModel);
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Ok");
            }
            else 
            {
                Console.WriteLine("Ko");
            }

            return new OkResult();
        }
    }
}
