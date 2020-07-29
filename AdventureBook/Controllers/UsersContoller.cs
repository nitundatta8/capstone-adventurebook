using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AdventureBook.Services;
using AdventureBook.Models;

namespace AdventureBook.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User userParam)
    {
      Console.WriteLine(userParam.Username + " ----  " + userParam.Password);

      var user = _userService.Authenticate(userParam.Username, userParam.Password);

      if (user == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var claimsIdentity = this.User.Identity as ClaimsIdentity;
      var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
      Console.WriteLine(" userId " + userId);
      var users = _userService.GetAll();
      return Ok(users);
    }
  }
}