using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Tiene las propiedades que se requieren para correr una pagina web
/// </summary>
public class PaginaWeb : System.Web.UI.Page
{
    private const string key = "sistemadgiai2016";
    public enum TipoMensaje
    {
        Informacion, Error, Advertencia
    }
    /// <summary>
    /// Muestra un mensaje al renderizar la pagina
    /// </summary>
    protected void Alert(Page pagina, string mensaje, string titulo = null)
    {
        string alerta = $"llamarAlertaInfo('{mensaje}','{titulo ?? "Informacion"}');";
        ScriptManager.RegisterClientScriptBlock(pagina, GetType(), "alert", alerta, true);
    }
    /// <summary>
    /// Muestra una notificacion en la parte inferior de la pagina
    /// </summary>
    /// <param name="pagina"></param>
    /// <param name="mensaje"></param>
    /// <param name="Tipo"></param>
    protected void Notificar(Page pagina,string mensaje,TipoMensaje Tipo)
    {
        string alerta = "";
        switch (Tipo)
        {
            case TipoMensaje.Informacion:
                alerta = $"notificarInfo('{mensaje}');";
                break;
            case TipoMensaje.Error:
                alerta = $"notificarError('{mensaje}')";
                break;
            case TipoMensaje.Advertencia:
                alerta = $"notificarAdv('{mensaje}')";
                break;
        }
        ScriptManager.RegisterClientScriptBlock(pagina, GetType(), "alert", alerta, true);
    }
    /// <summary>
    /// Muestra un mensaje feo sin estilo
    /// </summary>
    /// <param name="mensaje"></param>
    protected void AlertFeo(string mensaje)
    {
        RegistraScript($"alert('{mensaje}');");
    }
    /// <summary>
    /// Ejecuta codigo javascript
    /// </summary>
    /// <param name="script"></param>
    protected void RegistraScript(string script, string ScriptKey = "ScriptKey")
    {
        if (!ClientScript.IsStartupScriptRegistered(this.GetType(), ScriptKey))
            ClientScript.RegisterStartupScript(this.GetType(), ScriptKey, script, true);
    }
    protected void runScript(Page pagina,string alerta ) {

        ScriptManager.RegisterClientScriptBlock(pagina, GetType(), "alert", alerta, true);
    }
    /// <summary>
    /// Ejecuta codigo javascrip que dentro de un UpdatePanel
    /// </summary>
    /// <param name="pagina"></param>
    /// <param name="script"></param>
    /// <param name="ScriptKey"></param>
    protected void RegistraScript(Page pagina,string script, string ScriptKey = "ScriptKey")
    {
        ScriptManager.RegisterClientScriptBlock(pagina, GetType(), ScriptKey, script, true);
    }
    /// <summary>
    /// Encripta un string y retorna un chorizote como valor nuevo
    /// </summary>
    /// <param name="texto"></param>
    /// <returns></returns>
    public static string Encripta(string texto)
    {
        try
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);
            //Se utilizan las clases de encriptación MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            //Algoritmo TripleDES
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            //se regresa el resultado en forma de una cadena
            texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

        }
        catch (Exception)
        {

        }
        return texto;
    }
    /// <summary>
    /// Recibe el chorizote encriptado y regresa el valor original
    /// </summary>
    /// <param name="textoEncriptado"></param>
    /// <returns></returns>
    public static string Decripta(string textoEncriptado)
    {
        try
        {
            byte[] keyArray;
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();
            textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);
        }
        catch (Exception)
        {

        }
        return textoEncriptado;
    }
    /// <summary>
    /// Tiene las propiedades que tiene el usario actual
    /// </summary>
    public Usuario CurrentUser { get { return ((Usuario) Session["Usuario"]) ?? new Usuario(); } }

}