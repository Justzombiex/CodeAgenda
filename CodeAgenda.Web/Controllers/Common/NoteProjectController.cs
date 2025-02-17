using AutoMapper;
using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Application.Common.Commands.DeleteNote;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Application.Common.Queries.GetAllNotes;
using CodeAgenda.Application.Common.Queries.GetNoteById;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.Services.Interfaces.Common;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Services.Interfaces.Users;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteProjectController : ControllerBase
    {
        private readonly INoteProjectService _noteProjectService;
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public NoteProjectController(INoteProjectService noteProjectService, IProjectService projectService, IUserService userService, IMapper mapper)
        {
            _noteProjectService = noteProjectService;
            _userService = userService;
            _projectService = projectService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<NoteProjectDTO>>();

            try
            {
                var query = new GetAllNotesQuery();
                var noteProjects = await _noteProjectService.GetAll(query);

                rsp.status = true;
                rsp.value = noteProjects;
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
            var rsp = new Response<NoteProjectDTO?>();

            try
            {
                var query = new GetNoteByIdQuery(id);
                var noteProjectDto = await _noteProjectService.GetById(query);

                rsp.status = true;
                rsp.value = noteProjectDto;
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
        public async Task<IActionResult> Create([FromBody] NoteProjectDTO noteProjectDto)
        {
            var rsp = new Response<NoteProjectDTO>();
            try
            {
                var project = await _projectService.GetProjectById(noteProjectDto.ProjectId);
                var user = await _userService.GetUserById(noteProjectDto.UserId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var noteProject = _mapper.Map<NoteProject>(noteProjectDto);
                var command = new CreateNoteProjectCommand(noteProject.Content, user, project);

                rsp.status = true;
                rsp.value = await _noteProjectService.Create(command);
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
        public async Task<IActionResult> Edit([FromBody] NoteProjectDTO noteProjectDto)
        {
            var rsp = new Response<bool>();

            try
            {
                //TODO: Revisar el update
                var project = await _projectService.GetProjectById(noteProjectDto.ProjectId);

                var noteProject = _mapper.Map<NoteProject>(noteProjectDto);
                var command = new UpdateNoteProjectCommand(noteProject);

                rsp.status = true;
                await _noteProjectService.Update(command);
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
                var command = new DeleteNoteCommand(id);
                await _noteProjectService.Delete(command);
                rsp.value = true;
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

