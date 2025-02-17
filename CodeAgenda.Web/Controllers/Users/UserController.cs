using AutoMapper;
using CodeAgenda.Application.Users.Commands.CreateUser;
using CodeAgenda.Application.Users.Commands.DeleteUser;
using CodeAgenda.Application.Users.Commands.UpdateUser;
using CodeAgenda.Application.Users.Queries.GetAllUsers;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Users;
using CodeAgenda.Services.Interfaces.Users;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<UserDTO>>();

            try
            {
                var query = new GetAllUsersQuery();
                var userDtos = await _userService.GetAll(query);

                rsp.status = true;
                rsp.value = userDtos;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = new Response<UserDTO?>();

            try
            {
                var query = new GetUserByIdQuery(id);
                var userDto = await _userService.GetById(query);

                rsp.status = true;
                rsp.value = userDto;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UserDTO userDto)
        {
            var rsp = new Response<UserDTO>();

            try
            {
                var user = _mapper.Map<User>(userDto);
                var command = new CreateUserCommand(user.Name, user.FirstName, user.Email);

                rsp.status = true;
                rsp.value = await _userService.Create(command);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserDTO userDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var user = _mapper.Map<User>(userDto);
                var command = new UpdateUserCommand(user);

                rsp.status = true;
                await _userService.Update(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                var command = new DeleteUserCommand(id);
                await _userService.Delete(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
