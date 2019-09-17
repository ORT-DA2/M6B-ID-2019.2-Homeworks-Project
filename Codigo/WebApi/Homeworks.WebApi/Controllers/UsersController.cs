using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homeworks.BusinessLogic.Interface;
using Homeworks.Domain;
using Homeworks.WebApi.Models;
using Homeworks.WebApi.Filters;

namespace Homeworks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private ILogic<User> users;
        private ISession<UserSession> userSessions;
        public UsersController(ILogic<User> users, ISession<UserSession> userSessions) : base()
        {
            this.users = users;
            this.userSessions = userSessions;
        }

        // GET api/users
        [ProtectFilter("Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(users.GetAll());
        }

        // GET api/values/5
        [ProtectFilter("Admin")]
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(Guid id)
        {
            var user = users.Get(id);
            if(user == null)
            {
                return NotFound("No existe el usuario con id: "+id);
            }
            return Ok(new UserModel(user));
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            try
            {
                var newUser = users.Create(user.ToEntity());
                return Ok("Se genero un usuario con el id: "+newUser.Id);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] User user)
        {
            users.Update(id, user);
            return Ok("Se modifico correctamente");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            users.Remove(id);
        }
    }
}