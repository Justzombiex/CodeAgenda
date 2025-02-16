using AutoMapper;
using CodeAgenda.Application.Users.Commands.CreateUser;
using CodeAgenda.Application.Users.Commands.DeleteUser;
using CodeAgenda.Application.Users.Commands.UpdateUser;
using CodeAgenda.Application.Users.Queries.GetAllUsers;
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
                // Manejar la excepción adecuadamente
                throw new ApplicationException("Error al crear el usuario", ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                throw new ApplicationException("Error al eliminar el usuario", ex);
            }
        }

        public async Task<List<UserDTO>> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los usuarios", ex);
            }
        }

        public async Task Update(UserDTO userDto)
        {
            try
            {
                var command = new UpdateUserCommand(_mapper.Map<User>(userDto));
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar el usuario", ex);
            }
        }
    }

}
