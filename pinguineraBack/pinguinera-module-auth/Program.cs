using FluentValidation;
using Microsoft.EntityFrameworkCore;
using pinguinera_module_auth.Database;
using pinguinera_module_auth.Database.Interfaces;
using pinguinera_module_auth.Models.DataTransferObjects;
using pinguinera_module_auth.Models.Persistence.Repositories;
using pinguinera_module_auth.Models.Persistence.Repositories.Interfaces;
using pinguinera_module_auth.Services;
using pinguinera_module_auth.Services.Handler;
using pinguinera_module_auth.Services.Handler.Interfaces;
using pinguinera_module_auth.Services.Interfaces;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Database>( options => options.UseNpgsql( connectionString ) );
builder.Services.AddScoped<IDatabase, Database>();

//Validators
builder.Services.AddScoped<IValidator<LoginDTO>, LoginDTOValidator>();
builder.Services.AddScoped<IValidator<RegisterDTO>, RegisterDTOValidator>();
builder.Services.AddScoped<IValidator<RefreshTokenDTO>, RefreshTokenDTOValidator>();

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReaderRepository, ReaderRepository>();

//Handlers
builder.Services.AddScoped<IHashPassword, HashPassword>();
builder.Services.AddScoped<ICreateJWT, CreateJWT>();

//Services
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<IRefreshTokenService, RefreshTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
