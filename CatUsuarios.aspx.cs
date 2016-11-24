using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensiones.Extensiones;

public partial class CatUsuarios : PaginaWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
    }
    private void initEvents()
    {
        BtnUsuario.Click += BtnUsuario_Click;
        BtnUsuarioSeguir.Click += BtnUsuarioSeguir_Click;
        BtnEliminar.Click += BtnEliminar_Click;
    }
    private void agregarUsuario()
    {
        var ObjUsuarios = new SysUsuarios();
        string nombre = TxtNombre.Text.Trim();
        string pass = TxtPass.Text.Trim();
        string conf = TxtConfir.Text.Trim();
        if (pass.Equals(conf))
        {
            int id = ObjUsuarios.addUsuario(nombre, Encripta(pass), "", DdlRol.SelectedValue.ToEntero());
            if (id > 0)
            {
                Notificar(this, "Usuario agregado correctamente", TipoMensaje.Informacion);
            }
        }
        GvUsuarios.DataSource = ObjUsuarios.getUsuarios();
        ObjUsuarios.Dispose();
        GvUsuarios.DataBind();

        UpUsuarios.Update();
        UpDivUsuario.Update();

    }
    private void editarUsuario()
    {
        var ObjUsuarios = new SysUsuarios();
        string nombre = TxtNombre.Text.Trim();
        string pass = TxtPass.Text.Trim();
        string conf = TxtConfir.Text.Trim();
        int id = HdnID.Value.ToEntero();
        if (pass.Equals(conf))
        {
            if (ObjUsuarios.updateUsuario(id, nombre, Encripta(pass), DdlRol.SelectedValue.ToEntero()))
            {
                Notificar(this, "Usuario modificado correctamente", TipoMensaje.Informacion);
            }
        }
        GvUsuarios.DataSource = ObjUsuarios.getUsuarios();
        ObjUsuarios.Dispose();
        GvUsuarios.DataBind();

        UpUsuarios.Update();
        UpDivUsuario.Update();
    }
    private void BtnEliminar_Click(object sender, EventArgs e)
    {
       
    }

    private void BtnUsuarioSeguir_Click(object sender, EventArgs e)
    {
        if (HdnModalidad.Value == "A")
        {
            agregarUsuario();
        }
        else
        {
            editarUsuario();
        }
    }

    private void BtnUsuario_Click(object sender, EventArgs e)
    {
        if (HdnModalidad.Value == "A")
        {
            agregarUsuario();
            RegistraScript(this, "$('#DivUsuario').modal('hide');");
        }
        else
        {
            editarUsuario();
            RegistraScript(this, "$('#DivUsuario').modal('hide');");
        }
    }

    private void CargaDatos()
    {
        var ObjUsuarios = new SysUsuarios();
        GvUsuarios.DataSource = ObjUsuarios.getUsuarios();
        ObjUsuarios.Dispose();
        GvUsuarios.DataBind();
        UpUsuarios.Update();
    }

    protected void LnkEditar_Click(object sender, EventArgs e)
    {
        var lnk = sender as LinkButton;
        var GvRow = lnk.NamingContainer as GridViewRow;
        HdnModalidad.Value = "E";
        HdnID.Value = GvRow.DataKey("idUsuario");
        TxtNombre.Text = GvRow.DataKey("Username");
    }

    protected void LnkDelete_Click(object sender, EventArgs e)
    {
        var lnk = sender as LinkButton;
        var GvRow = lnk.NamingContainer as GridViewRow;
        int id = GvRow.DataKey("idUsuario").ToEntero();
        var objUsuarios = new SysUsuarios();
        if (objUsuarios.deleteUsuario(id))
        {
            Notificar(this, "Usuario agregado correctamente", TipoMensaje.Error);
            GvUsuarios.DataSource = objUsuarios.getUsuarios();

        }
        objUsuarios.Dispose();
        GvUsuarios.DataBind();
    }
}