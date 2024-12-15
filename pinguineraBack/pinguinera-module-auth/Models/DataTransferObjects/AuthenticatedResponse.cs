using pinguinera_module_auth.Models.Persistence.Enums;

namespace pinguinera_module_auth.Models.DataTransferObjects;

public class AuthenticatedResponse
{
	public string? Token { get; set; }
	public string Role { get; set; }
}

