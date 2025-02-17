using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;

namespace CodeAgenda.Services.Interfaces.Common
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
