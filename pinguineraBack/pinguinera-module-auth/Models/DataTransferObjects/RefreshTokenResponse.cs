namespace pinguinera_module_auth.Models.DataTransferObjects;

public class RefreshTokenResponse
{
	public string Token { get; set; }
	public string UserId { get; set; }
	public string UserName { get; set; }
}
