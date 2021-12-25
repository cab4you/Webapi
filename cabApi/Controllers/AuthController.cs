using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAdapters;
using CommanLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cabApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        public async Task <IActionResult> Registration(UserData userData)
        {
            try
            {
                Response response = new Response();
                response.data = await _authRepository.Register(userData);
                response.success = true;
                response.dateTime = DateTime.UtcNow;
                return Ok(response);
            }
            catch(Exception ex)
            {
                Response response = new Response();
                response.data = "";
                response.success = false;
                response.message = ex.Message;
                response.dateTime = DateTime.UtcNow;
                return BadRequest(response);
            }
        }
        [HttpGet("{userId}/{password}")]
        public async Task<IActionResult> Login(string userId,string password)
        {
            try
            {
                Response response = new Response();
                response.data = await _authRepository.Login(userId, password);
                response.success = true;
                response.dateTime = DateTime.UtcNow;
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.data = "";
                response.success = false;
                response.message = ex.Message;
                response.dateTime = DateTime.UtcNow;
                return BadRequest(response);
            }
        }
    }
}