using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homeworks.BusinessLogic.Interface;
using Homeworks.Domain;
using Homeworks.WebApi.Models;

[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private ISession<UserSession> sessions;

    public SessionsController(ISession<UserSession> sessions) : base()
    {
        this.sessions = sessions;
    }

    [HttpPost]
    public IActionResult Post([FromBody]LoginModel login) {
        Guid token;
        try 
        {
            token = sessions.Login(login.UserName, login.Password);
            return Ok(token);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public IActionResult Get([FromHeader] Guid token)
    {
        return Ok(sessions.isLogued(token));
    }
}