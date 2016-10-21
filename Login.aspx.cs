﻿using System;
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
        string usuario, password;
        usuario = TxtUsuario.Text.Trim();
        password = Encripta(TxtPassword.Text.Trim());
        //Agrega Usuarios 'Solo temporal'
        if (ChkTemporal.Checked)
        {
           int idUsuario = ObjUsuarios.addUsuario(usuario, TxtPassword.Text.Trim(),"ninguno@nadie.com");
            if (idUsuario > 0)
            {
                AlertFeo($"El nuevo usuario se grabo con el id = '{idUsuario}'");
            }
        }
        else
        {
            DataTable dtUsuarios = ObjUsuarios.getUsuarios();
            if (ObjUsuarios.HasUsuarios)
            {
                DataRow RowUsuario = dtUsuarios.FiltroPrimero($"Username='{TxtUsuario.Text.Trim()}' AND Contrasenia='{password}'");
                if (RowUsuario != null && RowUsuario["Username"].Equals(usuario) && RowUsuario["Contrasenia"].Equals(password))
                {
                    AlertFeo("Usuario Correcto");
                }
            }
        }
       
        ObjUsuarios.Dispose();
    }
}