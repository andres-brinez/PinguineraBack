using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;
using pinguinera_module_auth.Services.Handler.Interfaces;
using pinguinera_module_auth.Services.Interfaces;

namespace pinguinera_module_auth.Services;

public class RefreshTokenService( IUserRepository userRepository, ICreateJWT createJWT ) : IRefreshTokenService
{
	private readonly IUserRepository _userRepository = userRepository;
	private readonly ICreateJWT _createJWT = createJWT;

	public async Task<RefreshTokenResponse> Execute( string refreshToken )
	{
		var user = await _userRepository.GetByRefreshToken( refreshToken );
		if (user == null) throw new Exception( "Invalid refresh token" );

		var token = _createJWT.Execute( user );

		return new RefreshTokenResponse
		{
			Token = token,
			UserId = user.UserId.ToString(),
			UserName = user.Username!
		};
	}
}
