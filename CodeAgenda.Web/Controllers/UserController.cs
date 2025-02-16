using CodeAgenda.DTO.Users;
using CodeAgenda.Services.Interfaces;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<UserDTO>>();

            try
            {

                rsp.status = true;
                rsp.value = await _userService.GetAll();

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
