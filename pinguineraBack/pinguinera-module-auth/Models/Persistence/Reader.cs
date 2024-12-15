using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pinguinera_module_auth.Models.Persistence;
public partial class Reader
{
	[Key]
	[Column( "user_id" )]
	public Guid ReaderId { get; set; }
}
