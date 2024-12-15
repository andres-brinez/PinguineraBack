using FluentValidation;

namespace pinguinera_module_auth.Models.DataTransferObjects;

public class RegisterDTO
{
	public string? Username { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
}

public class RegisterDTOValidator: AbstractValidator<RegisterDTO>
{
	public RegisterDTOValidator()
	{
		RuleFor( x => x.Username ).NotEmpty().WithMessage( "Username is required" );
		RuleFor( x => x.Email ).NotEmpty().WithMessage( "Email is required" );
		RuleFor( x => x.Email ).EmailAddress().WithMessage( "Email is invalid" );
		RuleFor( x => x.Password ).NotEmpty().WithMessage( "Password is required" );
	}
}