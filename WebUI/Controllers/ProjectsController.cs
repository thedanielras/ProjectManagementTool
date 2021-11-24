using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Dtos;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
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
        public IActionResult ProjectDetailViewModal(Guid id) 
        {
            var project = _projectRepository.AllProjects.Where(p => p.ProjectId == id).FirstOrDefault();
            ResponseViewModel returnModel;

            if (project != null)
            {
                var payload = _mapper.Map<ProjectDto>(project);
                returnModel = new ResponseViewModel(payload);
            }
            else
            {
                returnModel = new ResponseViewModel(null, ResponseType.KO, "Project not found!");
            }

            return Json(returnModel);
        }
    }
}
