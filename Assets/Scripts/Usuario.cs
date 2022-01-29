using System;
using SQLite4Unity3d;

public class Usuario
{
    [PrimaryKey]
    public string NombreUsuario{get; set;}
    
    public string Nombre {get; set;}
    public string Apellido1 {get; set;}
    public string Apellido2 {get; set;}
    public string Password {get; set;}
    public string NombreNota {get; set;}
    public string Contenido{get; set;}
    public Usuario(string NombreUsuario, string Nombre, string Apellido1, string Apellido2, string Password, string NombreNota, string Contenido)
    {
        this.NombreUsuario = NombreUsuario;
        this.Nombre = Nombre;
        this.Apellido1 = Apellido1;
        this.Apellido2 = Apellido2;
        this.Password = Password;
        this.NombreNota = NombreNota;
        this.Contenido = Contenido;
    }
    public Usuario()
    {
        this.NombreUsuario = "";
        this.Nombre = "";
        this.Apellido1 = "";
        this.Apellido2 = "";
        this.Password = "";
        this.NombreNota = "";
        this.Contenido="";
    }

    public override bool Equals(object obj)
    {
        Usuario user = (Usuario) obj;
        return NombreUsuario == user.NombreUsuario; 
    }

    public override int GetHashCode()
    {
        return NombreUsuario.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format(
            "[Usuario: NombreUsuario={0}, Nombre={1}, Apellido1={2}, Apellido2={3}, Password={4}, NombreNota={5}, Contenido={6} ]",
            NombreUsuario, Nombre, Apellido1, Apellido2, Password, NombreNota, Contenido
        );
    }
}