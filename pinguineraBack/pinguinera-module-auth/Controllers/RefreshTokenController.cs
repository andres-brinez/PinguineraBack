using Microsoft.AspNetCore.Mvc;
using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Services.Interfaces;

namespace pinguinera_module_auth.Controllers;

[Route( "token" )]
public class RefreshTokenController( IRefreshTokenService refreshTokenService ) : ControllerBase
{
	private readonly IRefreshTokenService _refreshTokenService=refreshTokenService;

	[HttpPost( "refresh" )]
	public async Task<IActionResult> Refresh( [FromBody] RefreshTokenDTO refreshTokenDTO )
	{
		try
		{
			var result = await _refreshTokenService.Execute( refreshTokenDTO.Token );
			if (result == null) return BadRequest( "Error refreshing token" );

			return Ok( result );
		}
		catch (Exception e)
		{
			return BadRequest( e.Message );
		}
	}
}
