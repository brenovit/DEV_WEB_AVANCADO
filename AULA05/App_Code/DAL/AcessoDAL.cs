using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
public class AcessoDAL
{
    public AcessoDAL()
    {

    }

    protected static IDbConnection criaConexaOleDB()
    {
        String strConexao = (String)System.Configuration.ConfigurationManager.AppSettings["ConexaoOle"];
        OleDbConnection conexaoDB;
        conexaoDB = new OleDbConnection(strConexao);
        conexaoDB.Open();

        return conexaoDB;
    }

    protected static OleDbDataReader criaDataReader(String sql)
    {
        OleDbConnection cx = (OleDbConnection)criaConexaOleDB();
        OleDbCommand comm = new OleDbCommand(sql, cx);
        OleDbDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
        comm.Dispose(); //Dispose, mata o objeto (coloca nulo no ponteiro da memoria)

        return dr;
    }

    protected static OleDbDataAdapter criaDataAdapter(String sql)
    {
        OleDbDataAdapter da = new OleDbDataAdapter(sql, (OleDbConnection)criaConexaOleDB());
        DataSet ds = new DataSet();
        da.Fill(ds); // carrega a sql do DataApdater dentro do DataSet

        return da;
    }

    protected static DataSet criaDataSet(String sql)
    {
        OleDbDataAdapter da = new OleDbDataAdapter(sql, (OleDbConnection)criaConexaOleDB());
        DataSet ds = new DataSet();
        da.Fill(ds); // carrega a sql do DataApdater dentro do DataSet

        return ds;
    }

    protected static OleDbCommand criaDbCommand(String sql)
    {
        OleDbCommand comm = (OleDbCommand)criaConexaOleDB().CreateCommand();
        comm.CommandText = sql;
        comm.CommandType = CommandType.Text;

        return comm;
    }

    protected static OleDbCommand criaDbCommand(String sql, CommandType tipo)
    {
        OleDbCommand comm = (OleDbCommand)criaConexaOleDB().CreateCommand();
        comm.CommandText = sql;
        comm.CommandType = tipo;

        return comm;
    }

}