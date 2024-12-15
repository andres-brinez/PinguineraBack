using FluentValidation;

namespace pinguinera_module_auth.Models.DataTransferObjects;

public class RefreshTokenDTO
{
	public string Token { get; set; }
}

public class RefreshTokenDTOValidator : AbstractValidator<RefreshTokenDTO>
{
	public RefreshTokenDTOValidator()
	{
		RuleFor( x => x.Token ).NotEmpty().WithMessage( "Token is required" );
	}
}