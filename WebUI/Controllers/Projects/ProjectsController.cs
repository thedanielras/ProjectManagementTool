using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Departments.Queries.GetAllDepartmentsQuery;
using Application.Projects.Commands.Create;
using Application.Projects.Commands.Edit;
using Application.Projects.Commands.Remove;
using Application.Projects.Queries.GetAllProjects;
using Application.Projects.Queries.GetProjectDetails;
using Application.Projects.Queries.GetProjectEditData;
using Application.Projects.Queries.GetProjectForRemoval;
using Application.Users.Queries.GetAll;
using Application.Users.Queries.GetByName;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
using WebUI.ViewModels.Project.Remove;

namespace WebUI.Controllers
{
    [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm][Bind(Prefix = "Project")] EditProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }

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
            var currentUser = await Mediator.Send(new GetUserByNameQuery(User.Identity.Name));
            if (currentUser != null)
            {
                vm.Project.ResponsibleUserId = currentUser.UserId;
            }

            var view = await ViewRenderService.RenderToStringAsync("~/Views/Projects/Partial/_AddProject.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm][Bind(Prefix = "Project")] CreateProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }
       
        [HttpGet]
        public async Task<IActionResult> RemoveModal([FromQuery] GetProjectForRemovalQuery query) 
        {
            var projectRemovalDto = await Mediator.Send(query);     

            var vm = new RemoveProjectViewModel(projectRemovalDto);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Projects/Partial/_RemoveProject.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromForm][Bind(Prefix = "Project")] RemoveProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }
        
    }
}
