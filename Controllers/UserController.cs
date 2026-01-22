using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signInManager;
  public UserController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
  {
    _signInManager = signInManager;
    _tokenService = tokenService;
    _userManager = userManager;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
  {
    try
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var appUser = new AppUser
      {
        UserName = registerDto.Email,
        Email = registerDto.Email
      };
      var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
      if (!createdUser.Succeeded) return StatusCode(500, createdUser.Errors);
      var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
      if (!roleResult.Succeeded) return StatusCode(500, roleResult.Errors);
      return Ok(
        new NewUserDto
        {
          UserName = appUser.Email,
          Email = appUser.Email,
          Token = _tokenService.CreateToken(appUser)
        }
      );

    }
    catch (Exception e)
    {
      return StatusCode(500, e);
    }
  }
}