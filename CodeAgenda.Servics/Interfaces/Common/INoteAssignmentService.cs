using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Application.Common.Commands.DeleteNote;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Application.Common.Queries.GetAllNotes;
using CodeAgenda.Application.Common.Queries.GetNoteById;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;

namespace CodeAgenda.Services.Interfaces.Common
{
    public interface INoteAssignmentService
    {
        Task<NoteAssignmentDTO> Create(CreateNoteAssignmentCommand command);
        Task Delete(DeleteNoteCommand command);
        Task Update(UpdateNoteAssignmentCommand command);
        Task<List<NoteAssignmentDTO>> GetAll(GetAllNotesQuery query);
        Task<NoteAssignmentDTO> GetById(GetNoteByIdQuery query);
        Task<NoteAssignment?> GetNoteAssignmentById(Guid noteassignmentId);
    }
}
