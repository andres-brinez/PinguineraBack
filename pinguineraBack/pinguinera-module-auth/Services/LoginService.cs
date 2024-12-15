using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Models.Persistence;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;
using pinguinera_module_auth.Services.Handler.Interfaces;
using pinguinera_module_auth.Services.Interfaces;
using System.Text;

namespace pinguinera_module_auth.Services
{
	public class LoginService( IUserRepository userRepository, IHashPassword hashPassword, ICreateJWT createJWT ) : ILoginService
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IHashPassword _hashPassword = hashPassword;

		public async Task<AuthenticatedResponse> Execute( LoginDTO payload )
		{
			var user = await _userRepository.GetByEmail( payload.Email );

			if (user == null) throw new ArgumentException( "Incorrect email or password" );

			string storedHashedPassword = user.Password;
			byte[] storedSalt = user.Salt;
			string enteredPassword = payload.Password;

			string enteredPasswordHash = _hashPassword.Hash( enteredPassword, storedSalt );

			if (enteredPasswordHash != storedHashedPassword) throw new ArgumentException( "Incorrect email or password" );

			await _userRepository.GenerateRefreshToken(user);

			var response = new AuthenticatedResponse
			{
				Token = user.RefreshToken,
				Role = user.Role
			};

			return response;
		}
	}
}
