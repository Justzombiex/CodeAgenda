using AutoMapper;
using CodeAgenda.Application.Users.Commands.CreateUser;
using CodeAgenda.Application.Users.Commands.DeleteUser;
using CodeAgenda.Application.Users.Commands.UpdateUser;
using CodeAgenda.Application.Users.Queries.GetAllUsers;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Users;
using CodeAgenda.Services.Interfaces;
using MediatR;

namespace CodeAgenda.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UserDTO> Create(CreateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<UserDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al crear el usuario", ex);
            }
        }

        public async Task Delete(DeleteUserCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
            
                throw new ApplicationException("Error al eliminar el usuario", ex);
            }
        }

        public async Task<List<UserDTO>> GetAll(GetAllUsersQuery query)
        {
            try
            {
                var users = await _mediator.Send(query);
                var userDtos = _mapper.Map<List<UserDTO>>(users);
                return userDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los usuarios", ex);
            }
        }

        public async Task<UserDTO?> GetById(GetUserByIdQuery query)
        {
            try
            {
                var user = await _mediator.Send(query);
                var userDto = _mapper.Map<UserDTO>(user);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener el usuario", ex);
            }
        }

        public async Task Update(UpdateUserCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar el usuario", ex);
            }
        }
    }

}
