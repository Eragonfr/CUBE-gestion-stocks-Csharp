using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Services;

namespace Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

		[HttpGet]
		public ActionResult<List<User>> GetAll() => UserService.GetAll();
    }
}
