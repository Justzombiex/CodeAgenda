using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Assignments.Queries.GetAllTags;
using CodeAgenda.Application.Assignments.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.Services.Interfaces;
using MediatR;

namespace CodeAgenda.Services.Services
{
    public class TagProjectService : ITagProjectService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TagProjectService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TagProjectDTO> Create(CreateTagProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<TagProjectDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteTagCommand command)
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

        public async Task<List<TagProjectDTO>> GetAll(GetAllTagsQuery query)
        {
            try
            {
                var tagProjects = await _mediator.Send(query);
                var tagProject = _mapper.Map<List<TagProjectDTO>>(tagProjects.OfType<TagProject>());
                return tagProject;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<TagProjectDTO?> GetById(GetTagByIdQuery query)
        {
            try
            {
                var tagProject = await _mediator.Send(query);
                var tagProjectDTO = _mapper.Map<TagProjectDTO>(tagProject);
                return tagProjectDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateTagProjectCommand command)
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

        public async Task<TagProject?> GetTagProjectById(Guid tagProjectId)
        {
            var query = new GetTagByIdQuery(tagProjectId);
            var tagProjectDto = await _mediator.Send(query);
            var tagProject = _mapper.Map<TagProject>(tagProjectDto);
            return tagProject;
        }
    }
}
