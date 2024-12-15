using Microsoft.EntityFrameworkCore;
using pinguinera_module_auth.Database.Configuration;
using pinguinera_module_auth.Database.Interfaces;
using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Database;
public class Database(DbContextOptions options) : DbContext(options), IDatabase
{
	public DbSet<User> User { get; set; }
	public DbSet<Reader> Reader { get; set; }

	public async Task<bool> SaveAsync()
	{
		return await SaveChangesAsync() > 0;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		EntityConfiguration(modelBuilder);
	}

	private void EntityConfiguration(ModelBuilder modelBuilder)
	{
		new UserConfiguration(modelBuilder.Entity<User>());
		new ReaderConfiguration( modelBuilder.Entity<Reader>() );
	}
}

