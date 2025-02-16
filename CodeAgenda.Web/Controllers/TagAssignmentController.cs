using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Assignments.Queries.GetAllTags;
using CodeAgenda.Application.Assignments.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.Services.Interfaces;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagAssignmentController : ControllerBase
    {
        private readonly ITagAssignmentService _tagAssignmentService;
        private readonly IAssignmentService _assignmentService;

        public TagAssignmentController(ITagAssignmentService tagassignmentService)
        {
            _tagAssignmentService = tagassignmentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<TagAssignmentDTO>>();

            try
            {
                var query = new GetAllTagsQuery();
                var tagassignmentDtos = await _tagAssignmentService.GetAll(query);

                rsp.status = true;
                rsp.value = tagassignmentDtos;
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

                var assignment = _assignmentService.GetById(tagAssignmentDto.AssignmentId);

                var command = new CreateTagAssignmentCommand
                (
                    tagAssignmentDto.Name,
                    tagAssignmentDto.Color,
                    assignment
                );

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
        [Route("Edit/{id:guid}")]
        public async Task<IActionResult> Edit([FromBody] TagAssignmentDTO tagAssignmentDto, Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                var assignment = _assignmentService.GetById(tagAssignmentDto.AssignmentId);

                var tagAssignment = new TagAssignment
                (
                    tagAssignmentDto.Name,
                    tagAssignmentDto.Color,
                    assignment,
                    id

                );

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
