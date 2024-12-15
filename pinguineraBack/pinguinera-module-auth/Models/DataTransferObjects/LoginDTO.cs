using FluentValidation;

namespace pinguinera_module_auth.Models.DataTransferObjects;

public class LoginDTO
{
	public string? Email { get; set; }
	public string? Password { get; set; }
}

public class LoginDTOValidator : AbstractValidator<LoginDTO>
{
	public LoginDTOValidator()
	{
		RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
		RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
		RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
	}
}