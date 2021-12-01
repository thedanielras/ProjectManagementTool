using Application.Common.Interfaces.Repositories;
using Application.Projects.Queries.GetAllProjects;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Common.Interfaces;
using WebUI.Dtos;
using WebUI.Dtos.Project.AddProject;
using WebUI.Services;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProjectsController : BaseController<ProjectsController>
    {
        
        [HttpGet]
        public IActionResult Index() /*Entry point*/
        {
            return new RedirectToActionResult("List", "Projects", new { }, true);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }


        //public async Task<IActionResult> ListJson([FromQuery] GetAllProjectsQuery query)
        //{
        //    ResponseViewModel returnModel;

        //    var projects = await _mediator.Send(query);

        //    returnModel = new ResponseViewModel(projects);

        //    //var projects = _projectRepository.AllProjects.ToList();
        //    /*
        //    if (projects.Count > 0)
        //    {
        //        var payload = new ProjectsListViewModel(_mapper.Map<IEnumerable<ProjectDto>>(projects));
        //        returnModel = new ResponseViewModel(payload);
        //    } else
        //    {
        //        returnModel = new ResponseViewModel(null, ResponseType.KO, "Elements not found");
        //    }
        //    */
        //    return Json(returnModel);
        //}

        //[HttpGet]
        //public async Task<IActionResult> ProjectDetailViewModal(Guid id) 
        //{
        //    var project = _projectRepository.AllProjects.Where(p => p.ProjectId == id).FirstOrDefault();
        //    ResponseViewModel returnModel;

        //    if (project != null)
        //    {
        //        var projectDto = _mapper.Map<ProjectDto>(project);

        //        string result = await _viewRenderService.RenderToStringAsync("Projects/_ProjectDetails", projectDto);

        //        returnModel = new ResponseViewModel(result);
        //    }
        //    else
        //    {
        //        returnModel = new ResponseViewModel(null, ResponseType.KO, "Project not found!");
        //    }

        //    return Json(returnModel);
        //}

        //[HttpGet]
        //public async Task<IActionResult> NewProjectViewModal()
        //{
        //    var allDepartments = _departmentRepository.AlLDerartments;
        //    var allUsers = _userRepository.AllUsers;
        //    var projectSourceTypes = from ProjectSourceType projectSourceType in Enum.GetValues(typeof(ProjectSourceType))
        //                             select new SelectListItem { Text = projectSourceType.ToString(), Value = ((int)projectSourceType).ToString() };

        //    IEnumerable<SelectListItem> departmentSelectList = allDepartments.Select(x => new SelectListItem { Text = x.Name, Value = x.DepartmentId.ToString() }).ToList();
        //    IEnumerable<SelectListItem> userSelectList = allUsers.Select(u => new SelectListItem { Text = u.Name, Value = u.UserId.ToString() }).ToList();
        //    IEnumerable<SelectListItem> projectSourceTypeSelectList = projectSourceTypes;         

        //    var viewModel = new AddProjectViewModel(departmentSelectList, userSelectList, projectSourceTypeSelectList);

        //    ResponseViewModel returnModel;
        //    string result = await _viewRenderService.RenderToStringAsync("_AddProject", viewModel);
        //    returnModel = new ResponseViewModel(result);
        //    return Json(returnModel);
        //}

    //    [HttpPost]
    //    public IActionResult AddProject(AddProjectDto project)
    //    {
    //        ResponseViewModel returnModel = new ResponseViewModel(null, ResponseType.KO, "Error adding project!");

    //        if (ModelState.IsValid)
    //        {
    //            var projectEntity = _mapper.Map<Project>(project);
    //            if (projectEntity != null)
    //            {
    //                bool isSuccess = _projectRepository.AddProject(projectEntity);
    //                if (isSuccess) returnModel = new ResponseViewModel(projectEntity, ResponseType.OK);
    //            }
    //        }

    //        return Json(returnModel);
    //    }
    }
}
