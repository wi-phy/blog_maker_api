using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Entities;

namespace webapi.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
  [HttpPost("register")]
  public async Task<ActionResult<AppUser>> PostRegister([FromBody] RegisterUserDto userDto)
  {
    if (await UserExists(userDto.Username)) return BadRequest("Username is already taken");
    if (userDto.Password != userDto.ConfirmPassword) return BadRequest("Passwords do not match");

    using var hmac = new HMACSHA512();

    var user = new AppUser
    {
      UserName = userDto.Username.ToLower(),
      PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
      PasswordSalt = hmac.Key
    };

    await context.AddAsync(user);
    await context.SaveChangesAsync();

    return user;
  }

  [HttpPost("login")]
  public async Task<ActionResult<AppUser>> PostLogin([FromBody] LoginUserDto userDto)
  {
    var user = await context.Users.FirstOrDefaultAsync(user => user.UserName == userDto.Username.ToLower());
    if (user == null) return Unauthorized();

    using var hmac = new HMACSHA512(user.PasswordSalt);

    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));

    for (int i = 0; i < computedHash.Length; i++)
    {
      if (computedHash[i] != user.PasswordHash[i]) return Unauthorized();
    }

    return user;
  }

  private async Task<bool> UserExists(string username)
  {
    return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
  }
}
