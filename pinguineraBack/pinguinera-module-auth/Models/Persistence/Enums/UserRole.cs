using System.Text.Json.Serialization;

namespace pinguinera_module_auth.Models.Persistence.Enums;

[JsonConverter( typeof( JsonStringEnumConverter ) )]
public enum UserRole
{
	ADMIN,
	ASSISTANT,
	SUPPLIER,
	READER
}