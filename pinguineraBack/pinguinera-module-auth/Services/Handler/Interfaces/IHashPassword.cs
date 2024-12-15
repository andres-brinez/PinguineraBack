namespace pinguinera_module_auth.Services.Handler.Interfaces;

public interface IHashPassword
{
    string Hash(string password, byte[] salt);
    byte[] GenerateSalt();
}
