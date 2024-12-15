using Microsoft.EntityFrameworkCore;
using pinguinera_module_auth.Database.Interfaces;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;
using pinguinera_module_auth.Models.Persistence.Enums;

namespace pinguinera_module_auth.Models.Persistence.Repositories;

public class ReaderRepository( IDatabase database ) : IReaderRepository
{
	private readonly IDatabase _database = database;

	public async Task<User?> GetById( Guid id )
	{
		return await _database.User.FirstOrDefaultAsync( u => u.UserId == id && u.Role == UserRole.READER.ToString() );
	}

	public async Task<User?> GetByEmail( string email )
	{
		return await _database.User.FirstOrDefaultAsync( u => u.Email == email && u.Role == UserRole.READER.ToString() );
	}

	public async Task<User?> Add( User reader )
	{
		await _database.User.AddAsync( reader );
		await _database.Reader.AddAsync( new Reader { ReaderId = reader.UserId } );
		await _database.SaveAsync();
		return reader;
	}

	public async Task<bool> Exists( string email )
	{
		return await _database.User.AnyAsync( u => u.Email == email );
	}
}
