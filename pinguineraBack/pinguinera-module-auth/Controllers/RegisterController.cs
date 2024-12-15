using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Services.Interfaces;

namespace pinguinera_module_auth.Controllers;

[Route( "[controller]" )]
[ApiController]
public class RegisterController( IValidator<RegisterDTO> registerValidator, IRegisterService registerService ) : ControllerBase
{
	private readonly IValidator<RegisterDTO> _registerValidator = registerValidator;
	private readonly IRegisterService _registerService = registerService;

	[HttpPost( "register" )]
	public async Task<IActionResult> Register( [FromBody] RegisterDTO registerDTO )
	{
		try
		{
			var validatorResult = await _registerValidator.ValidateAsync( registerDTO );
			if (!validatorResult.IsValid) return BadRequest( validatorResult.Errors );

			var result = await _registerService.Execute( registerDTO );
			if (result == null) return BadRequest( "Error registering user" );

			return Ok( result );
		}
		catch (Exception e)
		{
			return BadRequest( e.Message );
		}
	}
}
