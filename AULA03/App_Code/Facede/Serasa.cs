using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Serasa
/// </summary>
public class Serasa
{
    public Serasa()
    {
    }

    public string estaNoSarasa(Pessoa pessoa)
    {
        if(pessoa.Cpf[0].Equals('1'))
            return pessoa.Nome + " : Consultado | Serasa - <strong>NEGADO</strong>";
        else
        return pessoa.Nome + " : Consultado | Serasa - <strong>LIBERADO</strong>";
    }
}