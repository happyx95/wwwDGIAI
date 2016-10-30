using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Extensiones.Extensiones;

/// <summary>
/// Summary description for ConPaises
/// </summary>
public class ConPaises
{
    #region A T R I B U T O S 
    private SqlConnection SqlConexion;
    private SqlDataAdapter SqlAdapter;
    private SqlTransaction SqlTransacc;
    private SqlCommand Comando;
    private DataTable Data;
    private bool disposedValue = false; // Para detectar llamadas redundantes
    #endregion

    #region F U N C I O N E S   Y   C O N S T R U C T O R

    public ConPaises(SqlTransaction TransaccionCompartida = null)
    {
        if (TransaccionCompartida == null)
        {
            SqlConexion = new SqlConnection();
            SqlConexion.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            SqlAdapter = new SqlDataAdapter();
            try
            {
                SqlConexion.Open();
            }
            catch (Exception)
            {

            }
        }
        else
        {
            SqlConexion = TransaccionCompartida.Connection;
            SqlTransacc = TransaccionCompartida;
            SqlAdapter = new SqlDataAdapter();
        }
    }
    private void StoredProcedure(string StrSql, CommandType TipoComando = CommandType.StoredProcedure)
    {
        Comando = new SqlCommand();
        Comando.Connection = SqlConexion;
        SqlAdapter.SelectCommand = Comando;
        SqlAdapter.SelectCommand.Parameters.Clear();
        SqlAdapter.SelectCommand.CommandText = StrSql;
        SqlAdapter.SelectCommand.CommandType = TipoComando;
        if (SqlTransacc != null)
        {
            SqlAdapter.SelectCommand.Transaction = SqlTransacc;
        }
        Data = new DataTable();
    }
    #endregion

    #region T R A N S A C C I O N E S  S Q L
    public SqlTransaction startTransactionSQL()
    {
        if (SqlTransacc == null)
        {
            SqlTransacc = SqlConexion.BeginTransaction();
        }
        return SqlTransacc;
    }
    /// <summary>
    /// Guarda los ultimos cambios realizados durante la transaccion en la base de datos
    /// </summary>
    public void Commit()
    {
        if (SqlTransacc != null)
        {
            SqlTransacc.Commit();
        }
    }
    /// <summary>
    /// Remueve los ultimos cambios realizados durante la transaccion en la base de datos
    /// </summary>
    public void Rollback()
    {
        if (SqlTransacc != null)
        {
            SqlTransacc.Rollback();
        }
    }
    #endregion

    #region P A I S E S - D A T A B A S E
    /// <summary>
    /// Retorna la lista de paises registrados en la base de datos
    /// </summary>
    /// <returns></returns>
    public DataTable getPaises(int idPais = -1)
    {
        try
        {
            //Comprueba si no se repite el nombre del usuario
            StoredProcedure("SP_Con_getPaises");
            SqlAdapter.SelectCommand.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
            SqlAdapter.Fill(Data);
        }
        catch (Exception ex)
        {
        }
        return Data;
    }

    #endregion

    #region C E R R A R  -  C O N E X I O N E S

    protected void CerrarConexiones(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (Data != null)
                {
                    Data.Dispose();

                }
                if (SqlAdapter != null)
                {
                    SqlAdapter.Dispose();
                }
                if (Comando != null)
                {
                    Comando.Dispose();
                }
                if (SqlConexion.State != ConnectionState.Closed)
                {
                    SqlConexion.Close();
                }
                if (SqlConexion != null)
                {
                    SqlConexion.Dispose();
                }
            }
        }
        disposedValue = true;
    }
    /// <summary>
    /// Libera los recursos de memoria que utlizaba el objeto
    /// </summary>
    public void Dispose()
    {
        CerrarConexiones(true);
        GC.SuppressFinalize(this);
    }

    #endregion


}