using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Database.Configuration;
public class UserConfiguration
{
	public UserConfiguration( EntityTypeBuilder<User> entityBuilder )
	{
		entityBuilder.ToTable( "user" );
		entityBuilder.HasKey( entity => entity.UserId );
		entityBuilder.Property( entity => entity.Username ).IsRequired();
		entityBuilder.Property( entity => entity.Email ).IsRequired();
		entityBuilder.Property( entity => entity.Password ).IsRequired();
		entityBuilder.Property( entity => entity.RegisterAt ).IsRequired();
		entityBuilder.Property( entity => entity.RefreshToken ).IsRequired( false );
		entityBuilder.Property( entity => entity.Role ).IsRequired( false );
		entityBuilder.Property( entity => entity.Salt ).IsRequired();
	}
}

