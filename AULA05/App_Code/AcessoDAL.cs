using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for AcessoDAL
/// </summary>
public class AcessoDAL
{
    public AcessoDAL()
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
}