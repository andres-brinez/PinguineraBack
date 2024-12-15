using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pinguinera_module_auth.Models.Persistence;
public class User
{
	[Key]
	[Column( "user_id" )]
	public Guid UserId { get; set; }
	[Column( "username" )]
	public string? Username { get; set; }
	[Column( "refresh_token" )]
	public string? RefreshToken { get; set; }
	[Column( "email" )]
	public string? Email { get; set; }
	[Column( "password" )]
	public string? Password { get; set; }
	[Column( "registered_at" )]
	public DateOnly RegisterAt { get; set; }
	[Column( "salt" )]
	public byte[]? Salt { get; set; }
	[Column( "role" )]
	public string? Role { get; set; }
}
