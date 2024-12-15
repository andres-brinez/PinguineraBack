namespace pinguinera_module_auth.Domain.Entities;
public class User
{
	public string? Username { get; set; }
	public string? RefreshToken { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
	public DateOnly RegisterAt { get; set; }

	public User( string username, string email, string password )
	{
		Username = username;
		Email = email;
		Password = password;
		RegisterAt = DateOnly.FromDateTime( DateTime.Now );
	}
}


