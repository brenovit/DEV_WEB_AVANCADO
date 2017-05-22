using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SPC
/// </summary>
public class SPC
{
    public SPC()
    {        
    }

    public string estaNoSpc(Pessoa pessoa)
    {
        if (pessoa.Cpf.Length > 11)
            return pessoa.Nome + " : Consultado | SPC - <strong>NEGADO</strong>";
        else
            return pessoa.Nome + " : Consultado | SPC - <strong>LIBERADO</strong>";
    }
}