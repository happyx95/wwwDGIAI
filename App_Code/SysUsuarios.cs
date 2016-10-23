using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Extensiones.Extensiones;

/// <summary>
/// Clase que permite agregar, editar, actualizar,obtener y eliminar usuarios de la base de datos
/// </summary>
public class SysUsuarios : IDisposable
{
    #region A T R I B U T O S 
    private SqlConnection SqlConexion;
    private SqlDataAdapter SqlAdapter;
    private SqlTransaction SqlTransacc;
    private SqlCommand Comando;
    private DataTable Data;
    private bool disposedValue = false; // Para detectar llamadas redundantes
    private bool HayUsuarios = false;
    private int ultimoUsuario = 0;
    #endregion

    #region F U N C I O N E S   Y   C O N S T R U C T O R
    
    public SysUsuarios(SqlTransaction TransaccionCompartida = null)
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

    #region U S U A R I O S - D A T A B A S E
    /// <summary>
    /// Agrega un nuevo usuario a la base de datos y retorna el 'Id' del usuario insertado
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="correo"></param>
    /// <param name="idRol"></param>
    /// <returns></returns>
    public int addUsuario(string username, string password, string correo, int idRol = 1)
    {
        int id = 0;
        string pass = PaginaWeb.Encripta(password);
        try
        {
            DataRow RowUsuarios = getUsuarios().FiltroPrimero($"Username='{username}'");
            //Comprueba si no se repite el nombre del usuario
            if (RowUsuarios == null)
            {
                StoredProcedure("SP_sys_addUsuarios");
                SqlAdapter.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                SqlAdapter.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
                SqlAdapter.SelectCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                SqlAdapter.SelectCommand.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                SqlAdapter.SelectCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlAdapter.Fill(Data);
                id = SqlAdapter.SelectCommand.Parameters["@idUsuario"].Value.ToString().ToEntero();
                ultimoUsuario = id;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            
        }
        return id;
    }
    /// <summary>
    /// Regresa una tabla con los usuarios que existen en la base de datos
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="idRol"></param>
    /// <returns></returns>
    public DataTable getUsuarios(int idUsuario = -1, int idRol = -1)
    {
        try
        {
            StoredProcedure("SP_sys_getUsuarios");
            SqlAdapter.SelectCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            SqlAdapter.SelectCommand.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            SqlAdapter.Fill(Data);
            HayUsuarios = Data.Rows.Count > 0;
        }
        catch (Exception)
        {

        }
        return Data;
    }
    #endregion

    #region P R O P I E D A D E S
    /// <summary>
    /// Regresa verdadero si la ultima consulta trajo 1 o mas usuarios
    /// </summary>
    public bool HasUsuarios { get { return HayUsuarios; } }
    /// <summary>
    /// Regresa la clave primaria del ultimo usuario agregado
    /// </summary>
    public int LastIdUsuarioInserted { get { return ultimoUsuario; } }
    #endregion

    #region C E R R A R  -  C O N E X I O N E S

    protected void CerrarConexiones(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (Data !=null)
                {
                    Data.Dispose();
                    
                }
                if (SqlAdapter != null)
                {
                    SqlAdapter.Dispose();
                }
                if (Comando !=null)
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