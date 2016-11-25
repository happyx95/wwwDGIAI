using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensiones.Extensiones;
using System.Data;

public partial class CatUsuarios : PaginaWeb
{
    private DataTable DtUsuarios { get { return (DataTable)ViewState["DtUsuarios"]; } set { ViewState["DtUsuarios"] = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        // initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
    }
    private void initEvents()
    {
        //BtnUsuario.Click += BtnUsuario_Click;
        //BtnUsuarioSeguir.Click += BtnUsuarioSeguir_Click;
        //BtnEliminar.Click += BtnEliminar_Click;
    }
    private void agregarUsuario()
    {
        var ObjUsuarios = new SysUsuarios();
        string nombre = TxtNombre.Text.Trim();
        string pass = TxtPass.Text.Trim();
        string conf = TxtConfir.Text.Trim();
        if (pass.Equals(conf))
        {
            int id = ObjUsuarios.addUsuario(nombre, pass, "", DdlRol.SelectedValue.ToEntero());
            if (id > 0)
            {
                Notificar(this, "Usuario agregado correctamente", TipoMensaje.Informacion);
            }
        }
        else
        {
            Notificar(this, "Las contraseñas con coinciden", TipoMensaje.Error);
            UpDivUsuario.Update();
            return;
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
            var DrUsuario = DtUsuarios.FiltroPrimero($"idUsuario={id} AND Contrasenia='{Encripta(pass)}'");
            if (DrUsuario != null)
            {
                if (ChkCambio.Checked)
                {
                    if (TxtNuevaPass.Text.Trim().Equals(TxtNuevaPassConf.Text.Trim()))
                    {
                        if (ObjUsuarios.updateUsuario(id, nombre, Encripta(TxtNuevaPass.Text.Trim()), DdlRol.SelectedValue.ToEntero()))
                        {
                            Notificar(this, "Usuario modificado correctamente", TipoMensaje.Informacion);
                            DtUsuarios = ObjUsuarios.getUsuarios();
                            GvUsuarios.DataSource = DtUsuarios;
                        }
                    }
                    else
                    {
                        Notificar(this, "Las contraseñas con coinciden", TipoMensaje.Error);
                    }
                }
                else
                {
                    if (ObjUsuarios.updateUsuario(id, nombre, Encripta(pass), DdlRol.SelectedValue.ToEntero()))
                    {
                        Notificar(this, "Usuario modificado correctamente", TipoMensaje.Informacion);
                        DtUsuarios = ObjUsuarios.getUsuarios();
                        GvUsuarios.DataSource = DtUsuarios;
                    }
                }
            }
            else
            {
                Notificar(this, "Contraseña incorrecta", TipoMensaje.Error);
            }
        }
        else
        {
            Notificar(this, "Las contraseñas con coinciden", TipoMensaje.Error);
        }
        
        ObjUsuarios.Dispose();
        GvUsuarios.DataBind();

        UpUsuarios.Update();
        UpDivUsuario.Update();
    }

    private void CargaDatos()
    {
        var ObjUsuarios = new SysUsuarios();
        DtUsuarios = ObjUsuarios.getUsuarios();
        GvUsuarios.DataSource = DtUsuarios;
        DdlRol.DataSource = ObjUsuarios.getRoles();
        ObjUsuarios.Dispose();
        GvUsuarios.DataBind();
        DdlRol.DataBind();
        UpUsuarios.Update();
    }

    protected void LnkEditar_Click(object sender, EventArgs e)
    {
        var lnk = sender as LinkButton;
        var GvRow = lnk.NamingContainer as GridViewRow;
        HdnModalidad.Value = "E";
        HdnID.Value = GvRow.DataKey("idUsuario");
        TxtNombre.Text = GvRow.DataKey("Username");
        CambioContraseña.Visible = true;
        UpUsuarios.Update();
        UpDivUsuario.Update();
        RegistraScript(this, "$('#DivUsuario').modal('show');$('#Titulo').text('Editar Usuario');");

    }

    protected void LnkDelete_Click(object sender, EventArgs e)
    {
        var lnk = sender as LinkButton;
        var GvRow = lnk.NamingContainer as GridViewRow;
        HdnIDEliminar.Value = GvRow.DataKey("idUsuario");
        UpEliminar.Update();
        RegistraScript(this, "$('#DivEliminar').modal('show');");
    }

    protected void BtnUsuario_Click1(object sender, EventArgs e)
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

    protected void BtnUsuarioSeguir_Click1(object sender, EventArgs e)
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

    protected void BtnEliminar_Click1(object sender, EventArgs e)
    {
        int id = HdnIDEliminar.Value.ToEntero();
        string pass = TxtPassEliminar.Text.Trim(), conf = TxtConfirEliminar.Text.Trim();
        if (pass.Equals(conf))
        {
            var DrUsuario = DtUsuarios.FiltroPrimero($"idUsuario={id} AND Contrasenia='{Encripta(pass)}'");
            if (DrUsuario != null)
            {
                var objUsuarios = new SysUsuarios();
                if (objUsuarios.deleteUsuario(id))
                {
                    Notificar(this, "Usuario eliminado correctamente", TipoMensaje.Informacion);
                    DtUsuarios = objUsuarios.getUsuarios();
                    GvUsuarios.DataSource = DtUsuarios;
                }
                objUsuarios.Dispose();
                GvUsuarios.DataBind();
            }
            else
            {
                Notificar(this, "Contraseña incorrecta", TipoMensaje.Error);
            }

        }
        else
        {
            Notificar(this, "Las contraseñas no coinciden", TipoMensaje.Error);
        }
        UpUsuarios.Update();
        UpEliminar.Update();
        RegistraScript(this, "$('#DivEliminar').modal('hide');");
    }

    protected void ChkCambio_CheckedChanged(object sender, EventArgs e)
    {
        DivNueva.Visible = ChkCambio.Checked;
        DivNuevaConf.Visible = ChkCambio.Checked;
        HdnModalidad.Value = "E";
        UpDivUsuario.Update();
        RegistraScript(this, "$('#Titulo').text('Editar Usuario');");
    }
}