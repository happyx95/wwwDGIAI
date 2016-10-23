using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
/// 
[Serializable]
public class Usuario
{
    public Usuario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int idUsuario { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Correo { get; set; }
    public int idRol { get; set; }
    public string Rol { get; set; }
}