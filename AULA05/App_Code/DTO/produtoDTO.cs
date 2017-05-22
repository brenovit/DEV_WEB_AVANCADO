using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tbVendaDTO
/// </summary>
public class ProdutoDTO
{
    public ProdutoDTO()
    {

    }
    public ProdutoDTO(int idProduto, String descricao, double valor, String fornecedor, int estoque)
    {
        this.idProduto = idProduto;
        this.dsDescricao = descricao;
        this.vlValor = valor;
        this.dsFornecedor = fornecedor;
        this.qtEstoque = estoque;
    }

    public int idProduto { get; set; }
    public String dsDescricao { get; set; }
    public double vlValor { get; set; }
    public String dsFornecedor { get; set; }

    public int qtEstoque { get; set; }
}