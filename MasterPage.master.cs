using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario user = (Usuario)Session["Usuario"];
                    LtlUsuario.Text = user.Username;
                }
            }
        }
    }
    private void initEvents()
    {
        LnlCerrarSesion.Click += LnlCerrarSesion_Click;
    }

    protected void LnlCerrarSesion_Click(object sender, EventArgs e)
    {
        try
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        catch (Exception)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}
