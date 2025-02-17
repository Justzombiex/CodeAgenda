using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Assignments.Queries.GetAllTags;
using CodeAgenda.Application.Assignments.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DTO.Assignments;

namespace CodeAgenda.Services.Interfaces
{
    public interface ITagProjectService
    {
        Task<TagProjectDTO> Create(CreateTagProjectCommand command);
        Task Delete(DeleteTagCommand command);
        Task Update(UpdateTagProjectCommand command);
        Task<List<TagProjectDTO>> GetAll(GetAllTagsQuery query);
        Task<TagProjectDTO> GetById(GetTagByIdQuery query);
        Task<TagProject?> GetTagProjectById(Guid tagProjectId);
    }
}
