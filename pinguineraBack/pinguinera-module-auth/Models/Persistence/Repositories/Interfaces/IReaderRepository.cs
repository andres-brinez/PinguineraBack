namespace pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;

public interface IReaderRepository
{
	public Task<User?> GetById( Guid id );
	public Task<User?> GetByEmail( string email );
	public Task<User?> Add( User reader );
	public Task<bool> Exists( string email );
}
