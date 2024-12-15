using Microsoft.IdentityModel.Tokens;
using pinguinera_module_auth.Models.Persistence;
using pinguinera_module_auth.Services.Handler.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pinguinera_module_auth.Services.Handler;

public class CreateJWT( IConfiguration configuration ) : ICreateJWT
{
	private readonly IConfiguration _configuration = configuration;

	public string Execute( User user )
	{
		var secretKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration["Jwt:Key"] ?? "secret" ) );
		var signInCredentials = new SigningCredentials( secretKey, SecurityAlgorithms.HmacSha256Signature );
		var tokenHandler = new JwtSecurityTokenHandler();

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity( new Claim[]
			{
				new ( "username" , user.Username! ),
				new ( "userId", user.UserId.ToString() ),
			} ),
			Expires = DateTime.UtcNow.AddHours( 1 ),
			SigningCredentials = signInCredentials
		};

		var token = tokenHandler.CreateToken( tokenDescriptor );
		var tokenString = tokenHandler.WriteToken( token );

		return tokenString;
	}
}
