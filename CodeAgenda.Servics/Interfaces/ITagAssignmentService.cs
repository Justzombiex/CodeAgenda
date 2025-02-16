using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Assignments.Queries.GetAllTags;
using CodeAgenda.Application.Assignments.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DTO.Assignments;

namespace CodeAgenda.Services.Interfaces
{
    public interface ITagAssignmentService
    {
        Task<TagAssignmentDTO> Create(CreateTagAssignmentCommand command);
        Task Delete(DeleteTagCommand command);
        Task Update(UpdateTagAssignmentCommand command);
        Task<List<TagAssignmentDTO>> GetAll(GetAllTagsQuery query);
        Task<TagAssignmentDTO> GetById(GetTagByIdQuery query);
        Task<TagAssignment?> GetTagAssignmentById(Guid tagassignmentId);
    }
}
