using CodeAgenda.Application.Users.Commands.CreateUser;
using CodeAgenda.Application.Users.Commands.DeleteUser;
using CodeAgenda.Application.Users.Commands.UpdateUser;
using CodeAgenda.Application.Users.Queries.GetAllUsers;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.DTO.Users;

namespace CodeAgenda.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(CreateUserCommand command);
        Task Delete(DeleteUserCommand command);
        Task Update(UpdateUserCommand command);
        Task<List<UserDTO>> GetAll(GetAllUsersQuery query);
        Task<UserDTO> GetById(GetUserByIdQuery query);
    }

}
