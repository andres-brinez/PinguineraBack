using pinguinera_module_auth.Services.Handler.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace pinguinera_module_auth.Services.Handler;

public class HashPassword : IHashPassword
{
	public string Hash( string password, byte[] salt )
	{
		using (var sha256 = new SHA256Managed())
		{
			byte[] passwordBytes = Encoding.UTF8.GetBytes( password );
			byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

			Buffer.BlockCopy( passwordBytes, 0, saltedPassword, 0, passwordBytes.Length );
			Buffer.BlockCopy( salt, 0, saltedPassword, passwordBytes.Length, salt.Length );

			byte[] hashedBytes = sha256.ComputeHash( saltedPassword );

			byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
			Buffer.BlockCopy( salt, 0, hashedPasswordWithSalt, 0, salt.Length );
			Buffer.BlockCopy( hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length );

			return Convert.ToBase64String( hashedPasswordWithSalt );
		}
	}

	public byte[] GenerateSalt()
	{
		byte[] salt = new byte[16];
		RandomNumberGenerator.Fill( salt );
		return salt;
	}
}
