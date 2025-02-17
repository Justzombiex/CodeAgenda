using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.Services.Interfaces.Assignments;
using CodeAgenda.Services.Interfaces.Common;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagAssignmentController : ControllerBase
    {
        private readonly ITagAssignmentService _tagAssignmentService;
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public TagAssignmentController(ITagAssignmentService tagassignmentService, IAssignmentService assignmentService, IMapper mapper)
        {
            _tagAssignmentService = tagassignmentService;
            _assignmentService = assignmentService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<TagAssignmentDTO>>();

            try
            {
                var query = new GetAllTagsQuery();
                var tagAssignments = await _tagAssignmentService.GetAll(query);

                rsp.status = true;
                rsp.value = tagAssignments;
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
            var rsp = new Response<TagAssignmentDTO?>();

            try
            {
                var query = new GetTagByIdQuery(id);
                var tagAssignmentDto = await _tagAssignmentService.GetById(query);

                rsp.status = true;
                rsp.value = tagAssignmentDto;
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
        public async Task<IActionResult> Create([FromBody] TagAssignmentDTO tagAssignmentDto)
        {
            var rsp = new Response<TagAssignmentDTO>();
            try
            {
                var assignment = await _assignmentService.GetAssignmentById(tagAssignmentDto.AssignmentId);

                if (assignment == null)
                {
                    rsp.status = false;
                    rsp.message = "Assignment not found";
                    return NotFound(rsp);
                }

                var tagAssignment = _mapper.Map<TagAssignment>(tagAssignmentDto);
                var command = new CreateTagAssignmentCommand(tagAssignment.Name, tagAssignment.Color, assignment);

                rsp.status = true;
                rsp.value = await _tagAssignmentService.Create(command);
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
        public async Task<IActionResult> Edit([FromBody] TagAssignmentDTO tagAssignmentDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var tagAssignment = _mapper.Map<TagAssignment>(tagAssignmentDto);
                var command = new UpdateTagAssignmentCommand(tagAssignment);

                rsp.status = true;
                await _tagAssignmentService.Update(command);
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
                var command = new DeleteTagCommand(id);
                await _tagAssignmentService.Delete(command);
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
