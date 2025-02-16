using CodeAgenda.Application.Users.Commands.CreateUser;
using CodeAgenda.DTO.Users;

namespace CodeAgenda.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(CreateUserCommand command);
        Task Delete(Guid id);
        Task<List<UserDTO>> GetAll();
        Task Update(UserDTO userDto);
    }

}
