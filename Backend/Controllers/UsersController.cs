using Backend.Logic.Intefaces;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogic<User> userLogic;

        public UsersController(ILogic<User> userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                return Ok(userLogic.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }


        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
        {
            try
            {
                return Ok(userLogic.Get(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                userLogic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }
    }
}
