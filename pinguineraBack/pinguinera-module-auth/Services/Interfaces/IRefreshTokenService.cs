using pinguinera_module_auth.Models.DataTransferObjects;

namespace pinguinera_module_auth.Services.Interfaces;

public interface IRefreshTokenService
{
	public Task<RefreshTokenResponse> Execute( string refreshToken );
}
