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
    protected void RegistraScript(string script)
    {
        const string ScriptKey = "ScriptKey";
        if (!ClientScript.IsStartupScriptRegistered(this.GetType(), ScriptKey))
            ClientScript.RegisterStartupScript(this.GetType(), ScriptKey, script, true);
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
}