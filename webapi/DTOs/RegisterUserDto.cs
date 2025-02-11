using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs;

public class RegisterUserDto : LoginUserDto
{
  [Required]
  public required string ConfirmPassword { get; set; }
}
