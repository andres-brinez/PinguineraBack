using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
	Task<User?> GetById( Guid id );
	Task<User?> GetByEmail( string email );
	Task<User?> GetByRefreshToken( string refreshToken );
	Task<User?> Add( User user );
	Task<User?> GenerateRefreshToken( User user );
}
