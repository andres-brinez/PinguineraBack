using pinguinera_module_auth.Models.DataTransferObjects;

namespace pinguinera_module_auth.Services.Interfaces;

public interface IRegisterService
{
	public Task<AuthenticatedResponse> Execute(RegisterDTO registerDTO);
}
