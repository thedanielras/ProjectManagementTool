using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Departments.Queries.GetAllDepartmentsQuery;
using Application.Projects.Commands.Create;
using Application.Projects.Commands.Edit;
using Application.Projects.Queries.GetAllProjects;
using Application.Projects.Queries.GetProjectDetails;
using Application.Projects.Queries.GetProjectEditData;
using Application.Users.Queries.GetAllUsersQuery;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
using WebUI.ViewModels.Project.Create;
using WebUI.ViewModels.Project.Details;
using WebUI.ViewModels.Project.Edit;

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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> DetailsModal(Guid projectId)
        {
            var query = new GetProjectDetailsQuery();
            query.ProjectId = projectId;

            if (query.ProjectId == null)
            {
                throw new ArgumentException("Unexcpected query parameter");
            }

            var project = await Mediator.Send(query);

            if (project == null)
            {
                throw new NotFoundException($"Project with id {query.ProjectId} was not found!");
            }

            var allDepartments = await Mediator.Send(new GetAllDepartmentsQuery());
            var allUsers = await Mediator.Send(new GetAllUsersQuery());
            var projectSourceTypes = from ProjectSourceType projectSourceType in Enum.GetValues(typeof(ProjectSourceType))
                                    select new SelectListItem { Text = projectSourceType.ToString(), Value = ((int)projectSourceType).ToString() };

            IEnumerable<SelectListItem> departmentSelectList =  allDepartments.Select(x => new SelectListItem { Text = x.Name, Value = x.DepartmentId.ToString() }).ToList();
            IEnumerable<SelectListItem> userSelectList = allUsers.Select(u => new SelectListItem { Text = u.Name, Value = u.UserId.ToString() }).ToList();
            IEnumerable<SelectListItem> projectSourceTypeSelectList = projectSourceTypes;

            var vm = new ProjectDetailsViewModel(project, departmentSelectList, userSelectList, projectSourceTypeSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Projects/Partial/_ProjectDetails.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> EditModal(Guid projectId)
        {
            var getProjectDataQuery = new GetProjectEditDataQuery();
            getProjectDataQuery.ProjectId = projectId;

            if (getProjectDataQuery.ProjectId == null)
            {
                throw new ArgumentException("Unexcpected query parameter");
            }

            var project = await Mediator.Send(getProjectDataQuery);

            if (project == null)
            {
                throw new NotFoundException($"Project with id {getProjectDataQuery.ProjectId} was not found!");
            }

            var allDepartments = await Mediator.Send(new GetAllDepartmentsQuery());
            var allUsers = await Mediator.Send(new GetAllUsersQuery());
            var projectSourceTypes = from ProjectSourceType projectSourceType in Enum.GetValues(typeof(ProjectSourceType))
                                     select new SelectListItem { Text = projectSourceType.ToString(), Value = ((int)projectSourceType).ToString() };

            IEnumerable<SelectListItem> departmentSelectList = allDepartments.Select(x => new SelectListItem { Text = x.Name, Value = x.DepartmentId.ToString() }).ToList();
            IEnumerable<SelectListItem> userSelectList = allUsers.Select(u => new SelectListItem { Text = u.Name, Value = u.UserId.ToString() }).ToList();
            IEnumerable<SelectListItem> projectSourceTypeSelectList = projectSourceTypes;

            var vm = new EditProjectViewModel(project, departmentSelectList, userSelectList, projectSourceTypeSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Projects/Partial/_EditProject.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> CreationModal()
        {         
            var allDepartments = await Mediator.Send(new GetAllDepartmentsQuery());
            var allUsers = await Mediator.Send(new GetAllUsersQuery());
            var projectSourceTypes = from ProjectSourceType projectSourceType in Enum.GetValues(typeof(ProjectSourceType))
                                     select new SelectListItem { Text = projectSourceType.ToString(), Value = ((int)projectSourceType).ToString() };

            IEnumerable<SelectListItem> departmentSelectList = allDepartments.Select(x => new SelectListItem { Text = x.Name, Value = x.DepartmentId.ToString() }).ToList();
            IEnumerable<SelectListItem> userSelectList = allUsers.Select(u => new SelectListItem { Text = u.Name, Value = u.UserId.ToString() }).ToList();
            IEnumerable<SelectListItem> projectSourceTypeSelectList = projectSourceTypes;

            var vm = new CreateProjectViewModel(departmentSelectList, userSelectList, projectSourceTypeSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Projects/Partial/_AddProject.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<IActionResult> AddProject([FromForm][Bind(Prefix = "Project")] CreateProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<IActionResult> EditProject([FromForm][Bind(Prefix = "Project")] EditProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
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
