namespace Proyecto_2_3101.Exceptions;

public class InvalidLoginException :Exception
{
    public InvalidLoginException() : base("Usuario y/o Contraseña incorrecto") {}
    public InvalidLoginException(string message) : base(message) {}
}