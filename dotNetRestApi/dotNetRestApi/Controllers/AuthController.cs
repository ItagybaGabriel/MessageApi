using dotNetRestApi.Domain.Models;
using dotNetRestApi.Domain.Models.DTOs;
using dotNetRestApi.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // GET
        [HttpGet("lista-usuarios")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            try
            {
                return Ok(await _userService.ListarTodosUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SigInDTO signInDto)
        {
            SsoDTO ssoDto = await _userService.SignIn(signInDto);

            if (ssoDto == null)
                return Unauthorized();

            return Ok(ssoDto);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDto)
        {
            try
            {
                SsoDTO ssoDto = await _userService.SignUp(signUpDto);

                return Ok(ssoDto);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("current-user")]
        [Authorize]
        public async Task<IActionResult> getCurrentUser()
        {
            //return Ok(String.Format("Autenticado - {0}", User.Identity.Name));
            try
            {
                return Ok(await _userService.GetCurrentUser());
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

    }
}
