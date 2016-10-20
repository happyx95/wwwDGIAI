using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensiones.Extensiones;
using System.Data;
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


        }
    }
    /// <summary>
    /// Favor de iniciar los eventos de los componentes a utilizar desde aqui para evitar mezclar los eventos con el codigo html
    /// </summary>
    private void initEvents() {
        BtnIngresar.Click += BtnIngresar_Click;
    }

    private void BtnIngresar_Click(object sender, EventArgs e)
    {
        SysUsuarios ObjUsuarios = new SysUsuarios();
        DataTable dtUsuarios = ObjUsuarios.getUsuarios();
        string usuario, password;
        usuario = TxtUsuario.Text.Trim();
        password = Encripta(TxtPassword.Text.Trim());
        if (ObjUsuarios.HasUsuarios)
        {
            DataRow RowUsuario = dtUsuarios.FiltroPrimero($"username={TxtUsuario.Text.Trim()} AND password={password}");
            if ( RowUsuario !=null && RowUsuario["username"].Equals(usuario) && RowUsuario["password"].Equals(password))
            {
                AlertFeo("Usuario Correcto");
            }
        }
        ObjUsuarios.Dispose();
    }
}