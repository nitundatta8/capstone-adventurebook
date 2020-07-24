using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AdventureBook.Models;
using AdventureBook.Helpers;

namespace AdventureBook.Services
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
  }

  public class UserService : IUserService
  {
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    // private List<User> _users = new List<User>
    //     {
    //         new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    //     };

    private readonly AppSettings _appSettings;
    private AdventureContext _db;

    public UserService(IOptions<AppSettings> appSettings, AdventureContext db)
    {
      _appSettings = appSettings.Value;
      _db = db;
    }

    public User Authenticate(string username, string password)
    {
      var user = new User(); // _db.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

      // return null if user not found
      if (user == null)
        return null;

      // authentication successful so generate jwt token
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);

      // remove password before returning
      user.Password = null;

      return user;
    }

    public IEnumerable<User> GetAll()
    {// return users without passwords
      Console.WriteLine("User created");
      List<User> u = new List<User> { };
      return u;
      // u = _db.Users.ToList();
      // return u.Select(x =>
      // {
      //   x.Password = null;
      //   Console.WriteLine("User created -- " + x);
      //   return x;
      // });
    }
  }
}