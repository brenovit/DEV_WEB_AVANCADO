using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Old
{
    public class AcessoDAL2
    {
        public AcessoDAL2()
        {
        }

        protected static IDbConnection CriaConexaoOledb()
        {
            string strConexao = (String)System.Configuration.ConfigurationManager.AppSettings["ConexaoOle"];
            OleDbConnection conexaoOleDB;
            conexaoOleDB = new OleDbConnection(strConexao);
            conexaoOleDB.Open();
            return conexaoOleDB;
        }

        protected static OleDbDataReader criaDataReader(String sql)
        {
            OleDbConnection cx = (OleDbConnection)CriaConexaoOledb();
            OleDbCommand comm = new OleDbCommand(sql, cx);
            OleDbDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            comm.Dispose();
            return dr;
        }

        protected static OleDbDataAdapter criaDataAdapter(String sql)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(sql, (OleDbConnection)CriaConexaoOledb());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return da;
        }

        protected static DataSet criaDataSet(String sql)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(sql, (OleDbConnection)CriaConexaoOledb());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        protected static OleDbCommand criaOleDbCommand(String sql)
        {
            OleDbCommand comm = (OleDbCommand)CriaConexaoOledb().CreateCommand();
            comm.CommandText = sql;
            comm.CommandType = CommandType.Text;
            return comm;
        }

        protected static OleDbCommand criaOleDbCommand(String sql, CommandType tipo)
        {
            OleDbCommand comm = (OleDbCommand)CriaConexaoOledb().CreateCommand();
            comm.CommandText = sql;
            comm.CommandType = tipo;
            return comm;
        }
    }   

}