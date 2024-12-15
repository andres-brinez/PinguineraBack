
using pinguinera_module_auth.Models.Persistence;

namespace pinguinera_module_auth.Services.Handler.Interfaces;

public interface ICreateJWT
{
	public string Execute( User user );
}
