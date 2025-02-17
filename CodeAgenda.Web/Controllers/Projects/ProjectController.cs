using AutoMapper;
using CodeAgenda.Application.Projects.Commands.CreateProject;
using CodeAgenda.Application.Projects.Commands.DeleteProject;
using CodeAgenda.Application.Projects.Commands.UpdateProject;
using CodeAgenda.Application.Projects.Queries.GetAllProjects;
using CodeAgenda.Application.Projects.Queries.GetProjectById;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Services.Interfaces.Users;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IUserService userService, IMapper mapper)
        {
            _projectService = projectService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<ProjectDTO>>();

            try
            {
                var query = new GetAllProjectsQuery();
                var projectDtos = await _projectService.GetAll(query);

                rsp.status = true;
                rsp.value = projectDtos;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = new Response<ProjectDTO?>();

            try
            {
                var query = new GetProjectByIdQuery(id);
                var projectDto = await _projectService.GetById(query);

                rsp.status = true;
                rsp.value = projectDto;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ProjectDTO projectDto)
        {
            var rsp = new Response<ProjectDTO>();

            try
            {

                var user = await _userService.GetUserById(projectDto.UserID);

                if (user == null)
                {
                    rsp.status = false;
                    rsp.message = "User not found";
                    return NotFound(rsp);
                }

                var project = _mapper.Map<Project>(projectDto);
                var command = new CreateProjectCommand(project.Name, project.Description, project.StartDate, project.EndDate, user);

                var createdProjectDto = await _projectService.Create(command);
                rsp.status = true;
                rsp.value = createdProjectDto;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] ProjectDTO projectDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var user = await _userService.GetUserById(projectDto.UserID);

                if (user == null)
                {
                    rsp.status = false;
                    rsp.message = "Usuario no encontrado";
                    return NotFound(rsp);
                }

                var project = _mapper.Map<Project>(projectDto);
                var command = new UpdateProjectCommand(project);

                rsp.status = true;
                await _projectService.Update(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                var command = new DeleteProjectCommand(id);
                await _projectService.Delete(command);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }
    }
}

