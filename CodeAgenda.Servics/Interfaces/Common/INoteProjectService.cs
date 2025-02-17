using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Application.Common.Commands.DeleteNote;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Application.Common.Queries.GetAllNotes;
using CodeAgenda.Application.Common.Queries.GetNoteById;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;

namespace CodeAgenda.Services.Interfaces.Common
{
    public interface INoteProjectService
    {
        Task<NoteProjectDTO> Create(CreateNoteProjectCommand command);
        Task Delete(DeleteNoteCommand command);
        Task Update(UpdateNoteProjectCommand command);
        Task<List<NoteProjectDTO>> GetAll(GetAllNotesQuery query);
        Task<NoteProjectDTO> GetById(GetNoteByIdQuery query);
        Task<NoteProject?> GetNoteProjectById(Guid noteProjectId);
    }
}
