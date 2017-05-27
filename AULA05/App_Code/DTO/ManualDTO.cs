using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tbVendaDTO
/// </summary>
public class ManualDTO
{
    public ProdutoDTO produto { get; set; }
    public String dsDescricao { get; set; }
    public DateTime dtValidade { get; set; }
    public int idManual { get; set; }

    public ManualDTO()
    {
        this.produto = new ProdutoDTO();
    }

}