using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Models.Persistence.Enums;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;
using pinguinera_module_auth.Services.Handler.Interfaces;
using pinguinera_module_auth.Services.Interfaces;

namespace pinguinera_module_auth.Services;

public class RegisterService( IReaderRepository readerRepository, IHashPassword hashPassword, ICreateJWT createJWT ) : IRegisterService
{
	private readonly IReaderRepository _readerRepository = readerRepository;
	private readonly IHashPassword _hashPassword = hashPassword;

	public async Task<AuthenticatedResponse> Execute( RegisterDTO payload )
	{
		var readerEntity = new Domain.Entities.User( payload.Username, payload.Email, payload.Password );

		byte[] salt = _hashPassword.GenerateSalt();
		string hashedPassword = _hashPassword.Hash( payload.Password!, salt );
		string base64Salt = Convert.ToBase64String( salt );

		byte[] retrievedSalt = Convert.FromBase64String( base64Salt );

		if (await _readerRepository.Exists( readerEntity.Email! )) throw new ArgumentException( "Email already exists" );

		var reader = new Models.Persistence.User
		{
			Email = readerEntity.Email,
			Username = readerEntity.Username,
			Password = hashedPassword,
			RegisterAt = readerEntity.RegisterAt,
			Salt = retrievedSalt,
			Role = UserRole.READER.ToString(),
			RefreshToken = Guid.NewGuid().ToString()
		};

		await _readerRepository.Add( reader );

		return new AuthenticatedResponse { Token = reader.RefreshToken, Role = reader.Role };
	}
}
