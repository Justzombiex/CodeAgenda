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
    public class NoteProjectService : INoteProjectService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NoteProjectService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<NoteProjectDTO> Create(CreateNoteProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<NoteProjectDTO>(result);
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

        public async Task<List<NoteProjectDTO>> GetAll(GetAllNotesQuery query)
        {
            try
            {
                var noteProjects = await _mediator.Send(query);
                var noteProject = _mapper.Map<List<NoteProjectDTO>>(noteProjects.OfType<NoteProject>());
                return noteProject;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<NoteProjectDTO?> GetById(GetNoteByIdQuery query)
        {
            try
            {
                var noteProject = await _mediator.Send(query);
                var noteProjectDTO = _mapper.Map<NoteProjectDTO>(noteProject);
                return noteProjectDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateNoteProjectCommand command)
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

        public async Task<NoteProject?> GetNoteProjectById(Guid noteProjectId)
        {
            var query = new GetNoteByIdQuery(noteProjectId);
            var noteProjectDto = await _mediator.Send(query);
            var noteProject = _mapper.Map<NoteProject>(noteProjectDto);
            return noteProject;
        }
    }
}
