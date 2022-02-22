using GroupChatMessageService.Model;
using GroupChatMessageService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/Users")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] AuthenticationModel model)
        {
            var user = new User() { UserName = model.Username, Password = model.Password };
            var result = _userRepo.CreateUser(user);
            
            if (user == null)
            {
                return BadRequest(new { message = "Error while creating user" });
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = new User() { UserName = model.Username,Password = model.Password};
            var result = _userRepo.Authenticate(user);
            if (result == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(result);
        }

    }
}
