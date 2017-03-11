using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataPrev
/// </summary>
public class DataPrev
{
    public DataPrev()
    {
    }

    public string possuiLimiteValor(Pessoa pessoa, double valor)
    {
        if (valor > 5000)
        {
            return pessoa.Nome + " : Consultado | DataPrev - Emprestimo <strong>LIBERADO</strong> de R$" + valor;
        }
        else
        {
            return pessoa.Nome + " : Consultado | DataPrev - Emprestimo <strong>NEGADO</strong> de R$" + valor;
        }
    }
}