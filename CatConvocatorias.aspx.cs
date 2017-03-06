using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Extensiones.Extensiones;

public partial class CatConvocatorias : PaginaWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
        if (GvConvocatorias.Rows.Count > 0)
        {
            GvConvocatorias.UseAccessibleHeader = true;
            GvConvocatorias.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


    }
    private void initEvents()
    {
        BtnConvocatoria.Click += BtnConvocatoria_Click;
        BtnConvocatoriaSeguir.Click += BtnConvocatoriaSeguir_Click;
        BtnEliminar.Click += BtnEliminar_Click;
    }


    private void CargaDatos()
    {
        var ObjDatos = new ConDatos();
        var ObjConvocatorias = new ConConvocatorias(ObjDatos.startTransactionSQL());

        DdlPais.DataSource = ObjDatos.getPaises();
        DdlAreas.DataSource = ObjDatos.getAreas();
        DdlNivel.DataSource = ObjDatos.getNiveles();

        GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, CurrentUser.idUsuario);

        ObjDatos.Commit();
        ObjDatos.Dispose();

        DdlPais.DataBind();
        DdlAreas.DataBind();
        DdlNivel.DataBind();
        GvConvocatorias.DataBind();

        DdlPais.Items.Insert(0, new ListItem("Seleccione", "-1"));
        DdlAreas.Items.Insert(0, new ListItem("Seleccione", "-1"));
        DdlNivel.Items.Insert(0, new ListItem("Seleccione", "-1"));

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();
    }
    protected void BtnConvocatoria_Click(object sender, EventArgs e)
    {
        if (HdnModalidad.Value == "A")
        {
            agregarConvocatoria();
            RegistraScript(this, "$('#DivConvocatoria').modal('hide');");
        }
        else
        {
            editarConvocatoria();
            RegistraScript(this, "$('#DivConvocatoria').modal('hide');");
        }
    }
    private void BtnConvocatoriaSeguir_Click(object sender, EventArgs e)
    {
        if (HdnModalidad.Value == "A")
        {
            agregarConvocatoria();
        }
        else
        {
            editarConvocatoria();
        }
    }

    private void agregarConvocatoria()
    {
        var ObjConvocatorias = new ConConvocatorias();
        string convocatoria = TxtNombre.Text.Trim();
        int idPais = DdlPais.SelectedValue.ToEntero();
      
        string duracion = DdlDuracion.SelectedValue;
        string link = TxtLink.Text.Trim();
        bool estado = true;
        string info = TxtInfo.Text;
        int idArea = DdlAreas.SelectedValue.ToEntero();
        int idNivel = DdlNivel.SelectedValue.ToEntero();

        if (string.IsNullOrEmpty(convocatoria))
        {
            Notificar(this, "Escriba una convocatoria", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (idPais <= 0)
        {
            Notificar(this, "Seleccione un pais", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }
        if (string.IsNullOrEmpty(txtFechaI.Text))
        {
            Notificar(this, "Seleccione una fecha inicial", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (string.IsNullOrEmpty(txtFechaF.Text))
        {
            Notificar(this, "Seleccione una fecha final", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        DateTime FechaI = txtFechaI.Text.Trim().ToDate();
        DateTime FechaF = txtFechaF.Text.Trim().ToDate();

        if ((FechaF - FechaI).TotalDays <= 0)
        {
            Notificar(this, "La fecha final es menor a la fecha menor", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }
        if (idNivel <= 0)
        {
            Notificar(this, "Seleccione un nivel de estudio", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (idArea <= 0)
        {
            Notificar(this, "Seleccione un area de estudio", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (string.IsNullOrEmpty(duracion))
        {
            Notificar(this, "Seleccione una duracion", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (ObjConvocatorias.addConvocatoria(convocatoria, idPais, FechaI, FechaF, duracion, link, estado, CurrentUser.idUsuario, info, idArea, idNivel))
        {
            Notificar(this, "Convocatoria agregada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, -1);
        }
        ObjConvocatorias.Dispose();
        GvConvocatorias.DataBind();
        borrarCampos();

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();
    }
    private void editarConvocatoria()
    {


        int idConvocatoria = HdnID.Value.ToEntero();
        string convocatoria = TxtNombre.Text.Trim();
        int idPais = DdlPais.SelectedValue.ToEntero();
        string duracion = DdlDuracion.SelectedValue;
        string link = TxtLink.Text.Trim();
        bool estado = true;
        string info = TxtInfo.Text;
        int idArea = DdlAreas.SelectedValue.ToEntero();
        int idNivel = DdlNivel.SelectedValue.ToEntero();

        if (string.IsNullOrEmpty(convocatoria))
        {
            Notificar(this, "Escriba una convocatoria", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (idPais <= 0)
        {
            Notificar(this, "Seleccione un pais", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }
        if (string.IsNullOrEmpty(txtFechaI.Text))
        {
            Notificar(this, "Seleccione una fecha inicial", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (string.IsNullOrEmpty(txtFechaF.Text))
        {
            Notificar(this, "Seleccione una fecha final", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        DateTime FechaI = txtFechaI.Text.Trim().ToDate();
        DateTime FechaF = txtFechaF.Text.Trim().ToDate();
        if ((FechaF - FechaI).TotalDays <= 0)
        {
            Notificar(this, "La fecha final es menor a la fecha menor", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }
        if (idNivel <= 0)
        {
            Notificar(this, "Seleccione un nivel de estudio", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (idArea <= 0)
        {
            Notificar(this, "Seleccione un area de estudio", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        if (string.IsNullOrEmpty(duracion))
        {
            Notificar(this, "Seleccione una duracion", TipoMensaje.Error);
            UpDivConvocatoria.Update();
            UpEliminar.Update();
            UpConvocatorias.Update();
            return;
        }

        var dbConvocatorias = new ConConvocatorias();
        if (dbConvocatorias.updateConvocatoria(idConvocatoria, convocatoria, idPais, FechaI, FechaF, duracion, link, estado, info, idArea, idNivel))
        {
            Notificar(this, "Convocatoria editada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = dbConvocatorias.getConvocatorias(-1, -1);
        }
        dbConvocatorias.Dispose();
        GvConvocatorias.DataBind();

        borrarCampos();

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();
    }
    private void borrarCampos()
    {
        TxtNombre.Text = "";
        TxtLink.Text = "";
        TxtInfo.Text = "";
        txtFechaF.Text = "";
        txtFechaI.Text = "";
        DdlDuracion.SelectedIndex = 0;
        DdlPais.SelectedIndex = 0;
        DdlAreas.SelectedIndex = 0;
    }

    protected void LnkEditar_Click(object sender, EventArgs e)
    {
        var LnkEditar = sender as LinkButton;
        var GvRow = LnkEditar.NamingContainer as GridViewRow;
        HdnModalidad.Value = "E";
        HdnID.Value = GvRow.DataKey("idConvocatoria");
        TxtNombre.Text = GvRow.DataKey("Convocatoria");
        DdlPais.SelectedValue = GvRow.DataKey("idPais");
        txtFechaI.Text = GvRow.DataKey("FechaI").ToDate().ToShortDateString();
        txtFechaF.Text = GvRow.DataKey("FechaF").ToDate().ToShortDateString();
        DdlDuracion.SelectedValue = GvRow.DataKey("Duracion");
        TxtLink.Text = GvRow.DataKey("Link");
        TxtInfo.Text = GvRow.DataKey("Info");
        DdlNivel.SelectedValue = GvRow.DataKey("idNivel");
        DdlAreas.SelectedValue = GvRow.DataKey("idArea");

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();

        RegistraScript(this, "$('#DivConvocatoria').modal('show');$('#Titulo').text('Editar Convocatoria');");
    }

    protected void LnkDelete_Click(object sender, EventArgs e)
    {
        var LnkEliminar = sender as LinkButton;
        var GvRow = LnkEliminar.NamingContainer as GridViewRow;
        HdnIDEliminar.Value = GvRow.DataKey("idConvocatoria");

        GvConvocatorias.UseAccessibleHeader = true;
        GvConvocatorias.HeaderRow.TableSection = TableRowSection.TableHeader;

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();
        RegistraScript(this, "$('#DivEliminar').modal('show');");
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        var ObjConvocatorias = new ConConvocatorias();
        int idConvocatoria = HdnIDEliminar.Value.ToEntero();
        if (ObjConvocatorias.deleteConvocatoria(idConvocatoria))
        {
            Notificar(this, "Convocatoria eliminada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, -1);
            GvConvocatorias.DataBind();
        }
        ObjConvocatorias.Dispose();

        UpDivConvocatoria.Update();
        UpEliminar.Update();
        UpConvocatorias.Update();
        RegistraScript(this, "$('#DivEliminar').modal('hide');");
    }
}