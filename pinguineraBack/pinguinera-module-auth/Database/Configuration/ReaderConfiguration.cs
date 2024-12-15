using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Database.Configuration;
public class ReaderConfiguration
{
	public ReaderConfiguration( EntityTypeBuilder<Reader> entityBuilder )
	{
		entityBuilder.ToTable( "reader" );
		entityBuilder.HasKey( entity => entity.ReaderId );
	}
}
