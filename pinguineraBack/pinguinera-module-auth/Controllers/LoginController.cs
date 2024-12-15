using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Services.Interfaces;
namespace pinguinera_module_auth.Controllers;

[Route( "auth" )]
[ApiController]
public class LoginController( ILoginService loginService, IValidator<LoginDTO> loginValidator ) : ControllerBase
{
	private readonly ILoginService _loginService = loginService;
	private readonly IValidator<LoginDTO> _loginValidator = loginValidator;

	[HttpPost( "login" )]
	public async Task<IActionResult> Login( [FromBody] LoginDTO loginDTO )
	{
		try
		{
			var validatorResult = await _loginValidator.ValidateAsync( loginDTO );
			if (!validatorResult.IsValid) return BadRequest( validatorResult.Errors );

			var result = await _loginService.Execute( loginDTO );
			if (result == null) return BadRequest( "Error logging user" );

			return Ok( result );
		}
		catch (Exception e)
		{
			return BadRequest( e.Message );
		}
	}

}
