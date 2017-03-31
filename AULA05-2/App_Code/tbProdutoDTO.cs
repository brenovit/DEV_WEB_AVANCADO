using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TbVendaDTO
/// </summary>
public class tbProdutoDTO
{

    public int idProduto { get; set; }
    public string descricao { get; set; }
    public double valor { get; set; }
    public string fornecedor { get; set; }

    public tbProdutoDTO()
    {
    }

    public tbProdutoDTO(int idProduto, string descricao, double valor, string fornecedor)
    {
        this.idProduto = idProduto;
        this.descricao = descricao;
        this.valor = valor;
        this.fornecedor = fornecedor;
    }

    
}