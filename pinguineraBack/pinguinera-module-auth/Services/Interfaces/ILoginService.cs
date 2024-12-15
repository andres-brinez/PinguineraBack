using pinguinera_module_auth.Models.DataTransferObjects;

namespace pinguinera_module_auth.Services.Interfaces
{
	public interface ILoginService
	{
		public Task<AuthenticatedResponse> Execute(LoginDTO loginDTO);
	}
}
