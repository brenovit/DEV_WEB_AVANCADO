using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClienteDTO
/// </summary>
public class ClienteDTO
{
    public int idCliente { get; set; }
    public string dsNome { get; set; }
    public string dsCPFCNPJ { get; set; }
    public string dsNomeComum { get; set; }
    public DateTime dtCadastro { get; set; }
    public double vlCapital { get; set; }    
}