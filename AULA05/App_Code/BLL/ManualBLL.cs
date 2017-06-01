using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// Summary description for ProdutoBLL
/// </summary>
public class ManualBLL : AcessoDAL
{
    private OleDbCommand command;
    private OleDbDataReader drOleDb;
    private OleDbDataAdapter daOleDb;
    private DataSet dsOleDb;
    public String erro { get; set; }

    public ManualBLL()
    {
        
    }

    private string montaQuery(ManualDTO manual)
    {
        string sql = "SELECT idManual,idProduto,dsdescricao,dtValidade FROM tbManual WHERE 1=1";

        
        if (manual.idManual > 0)
        {
            sql += "AND idManual = " + manual.idManual;
        }
        if (manual.produto.idProduto > 0)
        {
            sql += "AND idProduto = " + manual.produto.idProduto;
        }
        if (!string.IsNullOrEmpty(manual.dsDescricao))            
        {
            sql += "AND dsDescricao  LIKE '%" + manual.dsDescricao.Trim() + "%'";
        }
        /*if (manual.dtValidade != null)
        {
            sql += "AND dtValidade = " + manual.dtValidade;
        }*/

        return sql;
    }

    public ManualDTO buscaPorID(ManualDTO manul)
    {
        String sql = montaQuery(manul);

        ManualDTO manuRet = new ManualDTO();
        try
        {
            drOleDb = criaDataReader(sql);
            while (drOleDb.Read())
            {
                manuRet.idManual = (int)drOleDb["idManual"];                
                manuRet.produto.idProduto = (int)drOleDb["idProduto"];
                ProdutoBLL bll = new ProdutoBLL();
                manuRet.produto = bll.buscaPorID(manuRet.produto);
                manuRet.dsDescricao = (String)drOleDb["dsdescricao"];
                manuRet.dtValidade = (DateTime)drOleDb["dtValidade"];                
            }
        }
        catch (SystemException e)
        {
            this.erro = e.Message;
        }

        return manuRet;
    }


    public ListaDeManuais buscaTodos(ManualDTO prod)
    {
        ListaDeManuais listaRet = new ListaDeManuais();
        String sql = this.montaQuery(prod);
        try
        {
            drOleDb = criaDataReader(sql);
            while (drOleDb.Read())
            {
                ManualDTO dtoAux = new ManualDTO();
                dtoAux.idManual = (int)drOleDb["idManual"];
                dtoAux.produto.idProduto = (int)drOleDb["idProduto"];
                dtoAux.dsDescricao = (string)drOleDb["dsdescricao"];
                dtoAux.dtValidade = (DateTime)drOleDb["dtValidade"];
                listaRet.Add(dtoAux);
            }
        }
        catch (SystemException e)
        {
            erro = e.Message;
        }
        return listaRet;
    }

    private int maxId() // Irá pegar o ID maximo da tabela
    {
        String sSql = "SELECT Max(idManual) FROM tbManual";
        int idretorno = 1;
        try
        {
            drOleDb = criaDataReader(sSql);
            while (drOleDb.Read())
            {
                if (!DBNull.Value.Equals(drOleDb[0]))
                {
                    idretorno = (int)drOleDb[0] + 1;
                }
            }
        }
        catch (SystemException e)
        {
            erro = e.Message;
        }
        return idretorno;
    }

    public void cadastrar(ManualDTO prod)
    {
        int idManual = this.maxId();
        string sql = "";
        sql += "INSERT INTO tbManual (idManual, idProduto, dsDescricao, dtValidade) VALUES (?,?,?,?)";

        command = criaDbCommand(sql, CommandType.Text);

        command.Parameters.AddWithValue("@idManual", idManual);
        command.Parameters.AddWithValue("@idproduto", prod.produto.idProduto);
        command.Parameters.AddWithValue("@dsDescricao", prod.dsDescricao);
        command.Parameters.AddWithValue("@dtValidade", prod.dtValidade);

        try
        {
            //drOleDb = command.ExecuteReader();
            command.ExecuteNonQuery();
            drOleDb.Close();
            //int idAtual = (int)command.Parameters["RETURN_VALUE"].Value;
        }
        catch (SystemException e)
        {
            erro = e.Message;
        }
    }

    public void alterar(ManualDTO prod)
    {
        String sql = "";
        sql += "UPDATE tbManual SET dsdescricao = ?, dtValidade = ?, idProduto = ? WHERE idManual = ?;";

        command = criaDbCommand(sql, CommandType.Text);
                
        command.Parameters.AddWithValue("@dsDescricao", prod.dsDescricao);
        command.Parameters.AddWithValue("@dtValidade", prod.dtValidade);
        command.Parameters.AddWithValue("@idproduto", prod.produto.idProduto);
        command.Parameters.AddWithValue("@idManual", prod.idManual);

        try
        {
            drOleDb = command.ExecuteReader();
            drOleDb.Close();
        }
        catch (SystemException e)
        {
            erro = e.Message;
        }
    }

    public void excluir(ManualDTO prod)
    {
        String sql = "";
        sql += "DELETE FROM tbManual WHERE idManual = ?";

        command = criaDbCommand(sql, CommandType.Text);
        OleDbParameter parametro = command.Parameters.Add("@idManual", OleDbType.Integer);
        parametro.Value = prod.idManual;

        try
        {
            drOleDb = command.ExecuteReader();
            drOleDb.Close();
        }
        catch (SystemException e)
        {
            erro = e.Message;
        }
    }
}