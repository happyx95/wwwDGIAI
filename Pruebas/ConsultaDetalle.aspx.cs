﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Extensiones.Extensiones;

public partial class CatConvocatorias2 : PaginaWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
        else
        {
            //   OrdenaDatos();
        }

        // RegistraScript("$(document).ready(function () {$('.select2me').select2({tags: 'true',allowClear: true});});");
    }
    private void initEvents()
    {
        BtnConvocatoria.Click += BtnConvocatoria_Click;
        BtnEliminar.Click += BtnEliminar_Click;
    }
    private DataTable DtEjemplo()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Convocatoria", typeof(string));
        dt.Columns.Add("Vigencia", typeof(string));
        dt.Columns.Add("Pais", typeof(string));
        dt.Columns.Add("Duracion", typeof(string));
        dt.Columns.Add("Estado", typeof(string));

        dt.Rows.Add("Prueba1", "nose", "Happylandia", "2 años", "abierta");
        dt.Rows.Add("Prueba2", "nose", "Alemania", "3 años", "cerrada");
        dt.Rows.Add("Prueba3", "nose", "España", "1 año", "abierta");

        dt.AcceptChanges();
        return dt;
    }

    private void CargaDatos()
    {
        var ObjDatos = new ConDatos();
        var ObjConvocatorias = new ConConvocatorias(ObjDatos.startTransactionSQL());

        DdlPais.DataSource = ObjDatos.getPaises();
        DdlPais.DataBind();

        DdlAreas.DataSource = ObjDatos.getAreas();
        DdlAreas.DataBind();

        DdlNivel.DataSource = ObjDatos.getNiveles();
        DdlNivel.DataBind();

        GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, CurrentUser.idUsuario);
        GvConvocatorias.DataBind();

        ObjDatos.Commit();
        ObjDatos.Dispose();
        UpConvocatorias.Update();
        OrdenaDatos();
    }
    protected void BtnConvocatoria_Click(object sender, EventArgs e)
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
        DateTime FechaI = txtFechaI.Text.ToDate();
        DateTime FechaF = txtFechaF.Text.ToDate();
        string duracion = DdlDuracion.SelectedValue;
        string link = TxtLink.Text.Trim();
        bool estado = true;
        string info = TxtInfo.Text;
        int idArea = DdlAreas.SelectedValue.ToEntero();
        int idNivel = DdlNivel.SelectedValue.ToEntero();
        if (ObjConvocatorias.addConvocatoria(convocatoria, idPais, FechaI, FechaF, duracion, link, estado, CurrentUser.idUsuario, info, idArea, idNivel))
        {
            Notificar(this, "Convocatoria agregada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, CurrentUser.idUsuario);
            GvConvocatorias.DataBind();
        }
        ObjConvocatorias.Dispose();
        borrarCampos();
        UpConvocatorias.Update();
        RegistraScript(this, "$('#DivConvocatoria').modal('hide');");
    }
    private void editarConvocatoria()
    {
        var ObjConvocatorias = new ConConvocatorias();
        int idConvocatoria = HdnID.Value.ToEntero();
        string convocatoria = TxtNombre.Text.Trim();
        int idPais = DdlPais.SelectedValue.ToEntero();
        DateTime FechaI = txtFechaI.Text.ToDate();
        DateTime FechaF = txtFechaF.Text.ToDate();
        string duracion = DdlDuracion.SelectedValue;
        string link = TxtLink.Text.Trim();
        bool estado = true;
        string info = TxtInfo.Text;
        int idArea = DdlAreas.SelectedValue.ToEntero();
        int idNivel = DdlNivel.SelectedValue.ToEntero();
        if (ObjConvocatorias.updateConvocatoria(idConvocatoria, convocatoria, idPais, FechaI, FechaF, duracion, link, estado, info, idArea, idNivel))
        {
            Notificar(this, "Convocatoria editada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, CurrentUser.idUsuario);
            GvConvocatorias.DataBind();
        }
        ObjConvocatorias.Dispose();
        borrarCampos();
        UpConvocatorias.Update();
        RegistraScript(this, "$('#DivConvocatoria').modal('hide');");
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
    }
    private void OrdenaDatos()
    {
        if (GvConvocatorias.Rows.Count > 0)
        {
            GvConvocatorias.UseAccessibleHeader = true;
            GvConvocatorias.HeaderRow.TableSection = TableRowSection.TableHeader;
            RegistraScript(this, "CargaJavascript();");
        }
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
        RegistraScript(this, "$('#DivConvocatoria').modal('show');$('#Titulo').text('Editar Convocatoria');");
    }

    protected void LnkDelete_Click(object sender, EventArgs e)
    {
        var LnkEliminar = sender as LinkButton;
        var GvRow = LnkEliminar.NamingContainer as GridViewRow;
        HdnIDEliminar.Value = GvRow.DataKey("idConvocatoria");
        UpEliminar.Update();
        RegistraScript(this, "$('#DivEliminar').modal('show')");
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        var ObjConvocatorias = new ConConvocatorias();
        int idConvocatoria = HdnIDEliminar.Value.ToEntero();
        if (ObjConvocatorias.deleteConvocatoria(idConvocatoria))
        {
            Notificar(this, "Convocatoria eliminada correctamente", TipoMensaje.Informacion);
            GvConvocatorias.DataSource = ObjConvocatorias.getConvocatorias(-1, CurrentUser.idUsuario);
            GvConvocatorias.DataBind();
        }
        ObjConvocatorias.Dispose();
        UpConvocatorias.Update();
        RegistraScript(this, "$('#DivEliminar').modal('hide')");
    }
}