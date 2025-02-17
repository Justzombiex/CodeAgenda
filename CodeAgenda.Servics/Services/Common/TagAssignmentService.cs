﻿using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.Services.Interfaces.Common;
using MediatR;

namespace CodeAgenda.Services.Services.Common
{
    public class TagAssignmentService : ITagAssignmentService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TagAssignmentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TagAssignmentDTO> Create(CreateTagAssignmentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<TagAssignmentDTO>(result);
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

        public async Task<List<TagAssignmentDTO>> GetAll(GetAllTagsQuery query)
        {
            try
            {
                var tagAssignments = await _mediator.Send(query);
                var tagAssignment = _mapper.Map<List<TagAssignmentDTO>>(tagAssignments.OfType<TagAssignment>());
                return tagAssignment;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<TagAssignmentDTO?> GetById(GetTagByIdQuery query)
        {
            try
            {
                var tagAssignment = await _mediator.Send(query);
                var tagAssignmentDTO = _mapper.Map<TagAssignmentDTO>(tagAssignment);
                return tagAssignmentDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateTagAssignmentCommand command)
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

        public async Task<TagAssignment?> GetTagAssignmentById(Guid tagAssignmentId)
        {
            var query = new GetTagByIdQuery(tagAssignmentId);
            var tagAssignmentDto = await _mediator.Send(query);
            var tagAssignment = _mapper.Map<TagAssignment>(tagAssignmentDto);
            return tagAssignment;
        }
    }
}

