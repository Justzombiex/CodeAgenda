using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;

namespace CodeAgenda.Services.Interfaces.Common
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
