using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tbVendaDTO
/// </summary>
public class ManualDTO
{
    public ProdutoDTO prod { get; set; }
    public String dsDescricao { get; set; }
    public DateTime dtValidade { get; set; }
    public int idManual { get; set; }

    public ManualDTO()
    {
        this.prod = new ProdutoDTO();
    }
}