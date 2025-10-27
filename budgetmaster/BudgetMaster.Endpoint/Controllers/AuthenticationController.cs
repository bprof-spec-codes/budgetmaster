using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Entities.DTOs.User;
using BudgetMaster.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly AuthenticationLogic _logic;

        public AuthenticationController(AuthenticationLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _logic.RegisterAsync(dto);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new
            {
                message = result.Message,
                token = result.Token
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            //_logic.method();
            return Ok();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            //_logic.method();
            return Ok();
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            //_logic.method();
            return Ok();
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            //_logic.method();
            return Ok();
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            //_logic.method();
            return Ok();
        }
    }
}
