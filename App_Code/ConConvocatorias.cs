using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Extensiones.Extensiones;


/// <summary>
/// Summary description for ConConvocatorias
/// </summary>
public class ConConvocatorias
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

    public ConConvocatorias(SqlTransaction TransaccionCompartida = null)
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

    #region C O N V O C A T O R I A S - D A T A B A S E
    /// <summary>
    /// Agrega una nueva convocatoria a la base de datos y regresa true si la convocatoria fue agregada
    /// </summary>
    /// <returns></returns>
    public bool addConvocatoria(string convocatoria, int idPais, DateTime FechaI, DateTime FechaF, string Duracion, string Link, bool Estado, int idUsuario, string Info,int idArea,int idNivel)
    {
        bool retorno = false;
        try
        {
            StoredProcedure("SP_Con_addConvocatorias");
            SqlAdapter.SelectCommand.Parameters.Add("@Convocatoria", SqlDbType.VarChar).Value = convocatoria;
            SqlAdapter.SelectCommand.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
            SqlAdapter.SelectCommand.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI.ToShortDateString();
            SqlAdapter.SelectCommand.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF.ToShortDateString();
            SqlAdapter.SelectCommand.Parameters.Add("@Duracion", SqlDbType.VarChar).Value = Duracion;
            SqlAdapter.SelectCommand.Parameters.Add("@Link", SqlDbType.VarChar).Value = Link;
            SqlAdapter.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            SqlAdapter.SelectCommand.Parameters.Add("@Info", SqlDbType.VarChar).Value = Info;
            SqlAdapter.SelectCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            SqlAdapter.SelectCommand.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
            SqlAdapter.SelectCommand.Parameters.Add("@idNivel", SqlDbType.Int).Value = idNivel;
            SqlAdapter.Fill(Data);
            retorno = true;
        }
        catch (Exception ex)
        {
        }
        return retorno;
    }
    /// <summary>
    /// Actualiza una convocatoria ya existente
    /// </summary>
    /// <param name="idConvocatoria"></param>
    /// <param name="convocatoria"></param>
    /// <param name="idPais"></param>
    /// <param name="FechaI"></param>
    /// <param name="FechaF"></param>
    /// <param name="Duracion"></param>
    /// <param name="Link"></param>
    /// <param name="Estado"></param>
    /// <param name="Info"></param>
    /// <returns></returns>
    public bool updateConvocatoria(int idConvocatoria, string convocatoria, int idPais, DateTime FechaI, DateTime FechaF, string Duracion, string Link, bool Estado, string Info,int idArea,int idNivel)
    {
        bool retorno = false;
        try
        {
            StoredProcedure("SP_Con_updateConvocatorias");
            SqlAdapter.SelectCommand.Parameters.Add("@idConvocatoria", SqlDbType.Int).Value = idConvocatoria;
            SqlAdapter.SelectCommand.Parameters.Add("@Convocatoria", SqlDbType.VarChar).Value = convocatoria;
            SqlAdapter.SelectCommand.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
            SqlAdapter.SelectCommand.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI.ToShortDateString();
            SqlAdapter.SelectCommand.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF.ToShortDateString();
            SqlAdapter.SelectCommand.Parameters.Add("@Duracion", SqlDbType.VarChar).Value = Duracion;
            SqlAdapter.SelectCommand.Parameters.Add("@Link", SqlDbType.VarChar).Value = Link;
            SqlAdapter.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            SqlAdapter.SelectCommand.Parameters.Add("@Info", SqlDbType.VarChar).Value = Info;
            SqlAdapter.SelectCommand.Parameters.Add("@idArea", SqlDbType.Int).Value = idArea;
            SqlAdapter.SelectCommand.Parameters.Add("@idNivel", SqlDbType.Int).Value = idNivel;
            SqlAdapter.Fill(Data);
            retorno = true;
        }
        catch (Exception ex)
        {
        }
        return retorno;
    }
    public bool deleteConvocatoria(int idConvocatoria)
    {
        bool retorno = false;
        try
        {
            StoredProcedure("SP_Con_deleteConvocatorias");
            SqlAdapter.SelectCommand.Parameters.Add("@idConvocatoria", SqlDbType.Int).Value = idConvocatoria;
            SqlAdapter.Fill(Data);
            retorno = true;
        }
        catch (Exception ex)
        {
        }
        return retorno;
    }
    public DataTable getConvocatorias(int idPais, int idUsuario)
    {
        try
        {
            StoredProcedure("SP_Con_getConvocatorias");
            SqlAdapter.SelectCommand.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
            SqlAdapter.SelectCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            SqlAdapter.Fill(Data);
        }
        catch (Exception ex)
        {
            return new DataTable();
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