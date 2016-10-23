using System;
using Extensiones.Extensiones;
using System.Data;
using System.Web.Security;
/// <summary>
/// Pagina para acceder al sistema
/// </summary>
public partial class Login : PaginaWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            Form.DefaultButton = BtnIngresar.ClientID;
        }
    }
    /// <summary>
    /// Favor de iniciar los eventos de los componentes a utilizar desde aqui para evitar mezclar los eventos con el codigo html
    /// </summary>
    private void initEvents()
    {
        BtnIngresar.Click += BtnIngresar_Click;
    }

    private void BtnIngresar_Click(object sender, EventArgs e)
    {
        SysUsuarios ObjUsuarios = new SysUsuarios();
        string usuario, password;
        usuario = TxtUsuario.Text.Trim();
        password = Encripta(TxtPassword.Text.Trim());
        //Agrega Usuarios 'Solo temporal'
        //if (ChkTemporal.Checked)
        //{
        //    int idUsuario = ObjUsuarios.addUsuario(usuario, TxtPassword.Text.Trim(), "ninguno@nadie.com");
        //    if (idUsuario > 0)
        //    {
        //        AlertFeo($"El nuevo usuario se grabo con el id = '{idUsuario}'");
        //    }
        //    else
        //    {
        //        AlertFeo($"Ocurrio un error al guardar el usuario");
        //    }
        //}
        //else
        //{
            DataTable dtUsuarios = ObjUsuarios.getUsuarios();
            if (ObjUsuarios.HasUsuarios)
            {
                DataRow RowUsuario = dtUsuarios.FiltroPrimero($"Username='{TxtUsuario.Text.Trim()}' AND Contrasenia='{password}'");
                if (RowUsuario != null && RowUsuario["Username"].Equals(usuario) && RowUsuario["Contrasenia"].Equals(password))
                {
                    Usuario user = new Usuario()
                    {
                        idUsuario = RowUsuario["idUsuario"].ToString().ToEntero(),
                        Username = RowUsuario["Username"].ToString(),
                        idRol = RowUsuario["idRol"].ToString().ToEntero(),
                        Rol = RowUsuario["Rol"].ToString()
                    };
                    Session["Usuario"] = user;
                    if (Session["Usuario"] != null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(user.Username, false);
                    }
                }
                else
                {
                    Notificar(this, "Usuario Incorrecto", TipoMensaje.Error);
                }
            }
        //}
        ObjUsuarios.Dispose();
        UpLogin.Update();
    }
}