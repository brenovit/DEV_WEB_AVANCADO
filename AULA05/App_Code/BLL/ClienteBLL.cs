using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClienteBLL
/// </summary>
public class ClienteBLL : ConnectionFactory
{
    private string montaQuery(ClienteDTO cliente)
    {
        string sql = @"SELECT idCliente,dsNome,dsCPFCNPJ,dsNomeComum,dtCadastro,vlCapital FROM tbCliente WHERE 1=1 ";

        if (cliente.idCliente > 0)
        {
            sql += "AND idCliente = " + cliente.idCliente;
        }
        if (!string.IsNullOrEmpty(cliente.dsNome))
        {
            sql += "AND dsNome  LIKE '%" + cliente.dsNome.Trim() + "%'";
        }
        if (!string.IsNullOrEmpty(cliente.dsNomeComum))
        {
            sql += "AND dsNomeComum  LIKE '%" + cliente.dsNomeComum + "%'";
        }
        if (!string.IsNullOrEmpty(cliente.dsCPFCNPJ))
        {
            sql += "AND dsCPFCNPJ  LIKE '%" + cliente.dsCPFCNPJ + "%'";
        }
        if (cliente.vlCapital != 0.0)
        {
            sql += "AND vlCapital = " + cliente.vlCapital;
        }

        return sql;
    }

    public void cadastrar(ClienteDTO c)
    {
        try
        {
            CleanParameters();
            string sql = @"INSERT INTO tbCliente (dsNome,dsCPFCNPJ,dsNomeComum,dtCadastro,vlCapital) VALUES(?,?,?,?,?);";

            Factory.CommandText = sql;
            Factory.Parameters.AddWithValue("@dsNome", c.dsNome);
            Factory.Parameters.AddWithValue("@dsCPFCNPJ", c.dsCPFCNPJ);
            Factory.Parameters.AddWithValue("@dsNomeComum", c.dsNomeComum);
            Factory.Parameters.AddWithValue("@dtCadastro", DateTime.Now);
            Factory.Parameters.AddWithValue("@vlCapital", c.vlCapital);
            int i = ExecuteScalar(false);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro", ex);
        }
    }

    public void excluir(ClienteDTO c)
    {
        try
        {
            CleanParameters();
            string sql = @"DELETE FROM tbCliente WHERE idCliente = ?";
            Factory.CommandText = sql;
            
            Factory.Parameters.AddWithValue("@idCliente", c.idCliente);

            int i = ExecuteNonQuery(false);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro", ex);
        }
    }

    public void alterar(ClienteDTO c)
    {
        try
        {
            CleanParameters();
            string sql = @"UPDATE tbCliente set dsNome = ?, dsCPFCNPJ = ?, dsNomeComum = ?, vlCapital = ? WHERE idCliente = ?";
            Factory.CommandText = sql;

            Factory.Parameters.AddWithValue("@dsNome", c.dsNome);
            Factory.Parameters.AddWithValue("@dsCPFCNPJ", c.dsCPFCNPJ);
            Factory.Parameters.AddWithValue("@dsNomeComum", c.dsNomeComum);
            Factory.Parameters.AddWithValue("@vlCapital", c.vlCapital);
            Factory.Parameters.AddWithValue("@idCliente", c.idCliente);

            int i = ExecuteNonQuery(false);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro", ex);
        }
    }

    public ListaDeClientes buscaTodos(ClienteDTO cliente)
    {
        try
        {
            ListaDeClientes lista = new ListaDeClientes();
            CleanParameters();
            string sql = montaQuery(cliente);
            Factory.CommandText = sql;
            var dt = ExecuteReader();
            while (dt.Read())
            {
                ClienteDTO c = new ClienteDTO();
                c.idCliente = dt.GetInt32(0);
                c.dsNome = dt.GetString(1);
                c.dsCPFCNPJ = dt.GetString(2);
                c.dsNomeComum = dt.GetString(3);
                c.dtCadastro = dt.GetDateTime(4);
                c.vlCapital = dt.GetDouble(5);
                lista.Add(c);
            }
            Close();
            return lista;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro", ex);
        }
    }

    public ClienteDTO buscaPorID(ClienteDTO cliente)
    {
        try
        {
            ClienteDTO c = new ClienteDTO();
            CleanParameters();
            string sql = montaQuery(cliente);
            Factory.CommandText = sql;
            var dt = ExecuteReader();
            while (dt.Read())
            {
                c.idCliente = dt.GetInt32(0);
                c.dsNome = dt.GetString(1);
                c.dsCPFCNPJ = dt.GetString(2);
                c.dsNomeComum = dt.GetString(3);
                c.dtCadastro = dt.GetDateTime(4);
                c.vlCapital = dt.GetDouble(5);
            }
            Close();
            return c;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro", ex);
        }
    }

}