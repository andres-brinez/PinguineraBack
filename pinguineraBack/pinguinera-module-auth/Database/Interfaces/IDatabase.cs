using Microsoft.EntityFrameworkCore;
using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Database.Interfaces;
public interface IDatabase
{
	public DbSet<User> User { get; set; }
	public DbSet<Reader> Reader { get; set; }
	Task<bool> SaveAsync();
}
