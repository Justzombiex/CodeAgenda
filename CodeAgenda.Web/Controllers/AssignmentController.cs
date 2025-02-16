using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateAssignment;
using CodeAgenda.Application.Assignments.Commands.DeleteAssignment;
using CodeAgenda.Application.Assignments.Commands.UpdateAssignment;
using CodeAgenda.Application.Assignments.Queries.GetAllAssignments;
using CodeAgenda.Application.Assignments.Queries.GetAssignmnetById;
using CodeAgenda.Application.Projects.Queries.GetProjectById;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces;
using CodeAgenda.Services.Services;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public AssignmentController(IAssignmentService assignmentService, IProjectService projectService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<AssignmentDTO>>();

            try
            {
                var query = new GetAllAssignmentsQuery();
                var assignmentDtos = await _assignmentService.GetAll(query);

                rsp.status = true;
                rsp.value = assignmentDtos;
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
            var rsp = new Response<AssignmentDTO?>();

            try
            {
                var query = new GetAssignmentByIdQuery(id);
                var assignmentDto = await _assignmentService.GetById(query);

                rsp.status = true;
                rsp.value = assignmentDto;
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
        public async Task<IActionResult> Create([FromBody] AssignmentDTO assignmentDto)
        {
            var rsp = new Response<AssignmentDTO>();

            try
            {
                var project = await _projectService.GetProjectById(assignmentDto.ProjectId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var assignment = _mapper.Map<Assignment>(assignmentDto);
                var command = new CreateAssignmentCommand(
                    assignment.Name,
                    assignment.Description,
                    assignment.FinishDate,
                    assignment.Status,
                    project);

                var createdAssignmentDto = await _assignmentService.Create(command);
                rsp.status = true;
                rsp.value = createdAssignmentDto;
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
        public async Task<IActionResult> Edit([FromBody] AssignmentDTO assignmentDto)
        {
            var rsp = new Response<bool>();
            try
            {
                var project = await _projectService.GetProjectById(assignmentDto.ProjectId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var assignment = _mapper.Map<Assignment>(assignmentDto);
                var command = new UpdateAssignmentCommand(assignment);

                rsp.status = true;
                await _assignmentService.Update(command);
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
                var command = new DeleteAssignmentCommand(id);
                await _assignmentService.Delete(command);
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
