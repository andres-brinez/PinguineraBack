using Microsoft.EntityFrameworkCore;
using pinguinera_module_auth.Database.Interfaces;
using pinguinera_module_auth.Models.Persistence;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;

namespace pinguinera_module_auth.Models.Persistence.Repositories;

public class UserRepository( IDatabase database ) : IUserRepository
{
	private readonly IDatabase _database = database;

	public async Task<User?> GetById( Guid id )
	{
		return await _database.User.FirstOrDefaultAsync( u => u.UserId == id );
	}

	public async Task<User?> GetByEmail( string email )
	{
		return await _database.User.FirstOrDefaultAsync( u => u.Email == email );
	}

	public async Task<User?> GetByRefreshToken( string refreshToken )
	{
		return await _database.User.FirstOrDefaultAsync( u => u.RefreshToken == refreshToken );
	}

	public async Task<User?> Add( User user )
	{
		await _database.User.AddAsync( user );
		await _database.SaveAsync();
		return user;
	}

	public async Task<User?> GenerateRefreshToken( User user )
	{
		user.RefreshToken = Guid.NewGuid().ToString();
		await _database.SaveAsync();
		return user;
	}
}
