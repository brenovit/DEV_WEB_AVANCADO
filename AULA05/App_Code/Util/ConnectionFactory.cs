using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for ConnectionFactory
/// </summary>
public class ConnectionFactory
{
    private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConexaoOle"].ToString();
    private static IDbConnection _conn;
    private static OleDbDataReader _dataReader;
    private static OleDbCommand _command;
    private static OleDbTransaction _transaction;

    public ConnectionFactory() { }

    /// <summary>
    /// Main resource of the factory, to manipulate querys.
    /// </summary>
    protected static OleDbCommand Factory
    {
        get
        {
            if (_conn == null)
            {
                _conn = new OleDbConnection(connectionString);
                _command = new OleDbCommand();
                _command.Connection = (OleDbConnection)_conn;
            }

            return _command;
        }
        set { _command = value; }
    }

    /// <summary>
    /// Open the connection.
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    protected static bool Open(bool transaction)
    {
        try
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
            if (transaction)
            {
                if (_transaction == null)
                {
                    _transaction = (OleDbTransaction)_conn.BeginTransaction();
                    _command.Transaction = _transaction;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(Constants.ERRO_ABRIR_BANCO, ex);
        }
    }

    /// <summary>
    /// Close the connection and clean the transaction.
    /// </summary>
    /// <returns></returns>
    public static bool Close()
    {
        try
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();

            if (_dataReader != null)
                _dataReader.Close();

            _transaction = null;
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(Constants.ERRO_FECHAR_BANCO, ex);
        }
    }

    /// <summary>
    /// Ends the transaction.
    /// </summary>
    /// <param name="commit">Will you commit?</param>
    public static void EndTransaction(bool commit)
    {
        if (_transaction != null)
        {
            if (commit)
                _transaction.Commit();
            else
                _transaction.Rollback();
            Close();
        }
    }

    /// <summary>
    /// Clear the parameters in the Factory.
    /// </summary>
    protected static void CleanParameters()
    {
        Factory.Parameters.Clear();
    }

    /// <summary>
    /// Execute a SQL against the connection and return the number of rows affected.
    /// Recomended for: UPDATE and DELETE.
    /// </summary>
    /// <param name="transaction">Will be a transaction?</param>
    /// <returns>Number of rows affected</returns>
    protected static int ExecuteNonQuery(bool transaction)
    {
        if (string.IsNullOrWhiteSpace(_command.CommandText.Trim()))
            throw new Exception(Constants.ERRO_SEM_INSTRUCAO);

        int _return;
        Open(transaction);

        try
        {
            _return = _command.ExecuteNonQuery();
            return _return;
        }
        catch (Exception ex)
        {
            _return = -1;
            throw new Exception(string.Format(Constants.ERRO_EXECUTAR_COMANDO, ex.Message), ex);
        }
        finally
        {
            if (!transaction)
                Close();
        }
    }

    /// <summary>
    /// Execute the query, and return the first column of the first row.
    /// Can be used with SELECT SCOPE_IDENTITY() for SQLServer.
    /// Recomended for: INSERT.
    /// </summary>
    /// <param name="transaction">Will be a transaction</param>
    /// <returns>Number of rows affected</returns>
    protected static int ExecuteScalar(bool transaction)
    {
        if (string.IsNullOrWhiteSpace(_command.CommandText.Trim()))
            throw new Exception(Constants.ERRO_SEM_INSTRUCAO);

        int _return;
        Open(transaction);

        try
        {
            _return = Convert.ToInt32(_command.ExecuteScalar());
            return _return;
        }
        catch (Exception ex)
        {
            _return = -1;
            throw new Exception(string.Format(Constants.ERRO_EXECUTAR_COMANDO, ex.Message), ex);
        }
        finally
        {
            if (!transaction)
                Close();
        }
    }

    /// <summary>
    /// Send the Query to the Connection, builds and return a DataTable.
    /// Recomended for: SELECT.
    /// Necessary close the connection manually, invoke Close().
    /// </summary>
    /// <param name="transaction">Will be a transaction</param>
    /// <returns>Number of rows affected</returns>
    protected static OleDbDataReader ExecuteReader()
    {
        if (string.IsNullOrWhiteSpace(_command.CommandText.Trim()))
            throw new Exception(Constants.ERRO_SEM_INSTRUCAO);

        Open(false);

        try
        {
            _dataReader = _command.ExecuteReader(CommandBehavior.CloseConnection);
            return _dataReader;
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format(Constants.ERRO_EXECUTAR_COMANDO, ex.Message), ex);
        }
    }

}