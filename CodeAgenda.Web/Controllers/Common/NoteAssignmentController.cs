using AutoMapper;
using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Application.Common.Commands.DeleteNote;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Application.Common.Queries.GetAllNotes;
using CodeAgenda.Application.Common.Queries.GetNoteById;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.DTO.Users;
using CodeAgenda.Services.Interfaces.Assignments;
using CodeAgenda.Services.Interfaces.Common;
using CodeAgenda.Services.Interfaces.Users;
using CodeAgenda.Services.Services.Common;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteAssignmentController : ControllerBase
    {
        private readonly INoteAssignmentService _noteAssignmentService;
        private readonly IAssignmentService _assignmentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public NoteAssignmentController(INoteAssignmentService noteAssignmentService, IAssignmentService assignmentService,IUserService userService, IMapper mapper)
        {
            _noteAssignmentService = noteAssignmentService;
            _userService = userService;
            _assignmentService = assignmentService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<NoteAssignmentDTO>>();

            try
            {
                var query = new GetAllNotesQuery();
                var noteAssignments = await _noteAssignmentService.GetAll(query);

                rsp.status = true;
                rsp.value = noteAssignments;
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
            var rsp = new Response<NoteAssignmentDTO?>();

            try
            {
                var query = new GetNoteByIdQuery(id);
                var noteAssignmentDto = await _noteAssignmentService.GetById(query);

                rsp.status = true;
                rsp.value = noteAssignmentDto;
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
        public async Task<IActionResult> Create([FromBody] NoteAssignmentDTO noteAssignmentDto)
        {
            var rsp = new Response<NoteAssignmentDTO>();
            try
            {
                var assignment = await _assignmentService.GetAssignmentById(noteAssignmentDto.AssignmentId);
                var user = await _userService.GetUserById(noteAssignmentDto.UserId);

                if (assignment == null)
                {
                    rsp.status = false;
                    rsp.message = "Assignment not found";
                    return NotFound(rsp);
                }

                var noteAssignment = _mapper.Map<NoteAssignment>(noteAssignmentDto);
                var command = new CreateNoteAssignmentCommand(noteAssignment.Content, user, assignment);

                rsp.status = true;
                rsp.value = await _noteAssignmentService.Create(command);
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
        public async Task<IActionResult> Edit([FromBody] NoteAssignmentDTO noteAssignmentDto)
        {
            var rsp = new Response<bool>();

            try
            {
                //TODO: Revisar el update
                var assignment = await _assignmentService.GetAssignmentById(noteAssignmentDto.AssignmentId);

                var noteAssignment = _mapper.Map<NoteAssignment>(noteAssignmentDto);
                var command = new UpdateNoteAssignmentCommand(noteAssignment);

                rsp.status = true;
                await _noteAssignmentService.Update(command);
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
                await _noteAssignmentService.Delete(command);
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
