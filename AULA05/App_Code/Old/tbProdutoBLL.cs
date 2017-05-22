using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Old
{
    public class tbProdutoBLL : AcessoDAL
    {
        public tbProdutoBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private OleDbCommand command;
        private OleDbDataReader drOleDb;
        private OleDbDataAdapter daOleDb;
        private DataSet dsOleDb;

        public String erro { get; set; }

        private String montaQuery(tbProdutoDTO produto)
        {
            String sql = "SELECT idProduto, descricao, valor, fornecedor from tbProduto WHERE 1=1";

            if (produto.idProduto > 0)
            {
                sql += "AND idProduto = " + produto.idProduto;
            }

            if (produto.descricao.Trim() != "")
            {
                sql += "AND descricao LIKE '%" + produto.descricao.Trim() + "%'";
            }

            if (produto.valor != 0.0)
            {
                sql += "AND valor = " + produto.valor;
            }

            if (produto.fornecedor.Trim() != "")
            {
                sql += "AND fornecedor LIKE '%'" + produto.fornecedor.Trim() + "'%'";
            }

            return sql;
        }

        public tbProdutoDTO buscaPorID(tbProdutoDTO prod)
        {
            String sql = montaQuery(prod);
            tbProdutoDTO prodRet = new tbProdutoDTO();

            try
            {
                drOleDb = criaDataReader(sql);
                while (drOleDb.Read())
                {
                    prodRet.idProduto = (int)drOleDb["idProduto"];
                    prodRet.descricao = (String)drOleDb["descricao"];
                    prodRet.valor = (double)drOleDb["valor"];
                    prodRet.fornecedor = (String)drOleDb["fornecedor"];
                }
            }
            catch (SystemException e)
            {
                this.erro = e.Message;
            }
            return prodRet;
        }
    }
}