using AutoMapper;
using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Application.Common.Commands.DeleteNote;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Application.Common.Queries.GetAllNotes;
using CodeAgenda.Application.Common.Queries.GetNoteById;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.Services.Interfaces.Common;
using MediatR;

namespace CodeAgenda.Services.Services.Common
{
    public class NoteAssignmentService : INoteAssignmentService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NoteAssignmentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<NoteAssignmentDTO> Create(CreateNoteAssignmentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<NoteAssignmentDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteNoteCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<NoteAssignmentDTO>> GetAll(GetAllNotesQuery query)
        {
            try
            {
                var noteAssignments = await _mediator.Send(query);
                var noteAssignment = _mapper.Map<List<NoteAssignmentDTO>>(noteAssignments.OfType<NoteAssignment>());
                return noteAssignment;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<NoteAssignmentDTO?> GetById(GetNoteByIdQuery query)
        {
            try
            {
                var noteAssignment = await _mediator.Send(query);
                var noteAssignmentDTO = _mapper.Map<NoteAssignmentDTO>(noteAssignment);
                return noteAssignmentDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateNoteAssignmentCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<NoteAssignment?> GetNoteAssignmentById(Guid noteAssignmentId)
        {
            var query = new GetNoteByIdQuery(noteAssignmentId);
            var noteAssignmentDto = await _mediator.Send(query);
            var noteAssignment = _mapper.Map<NoteAssignment>(noteAssignmentDto);
            return noteAssignment;
        }
    }
}
