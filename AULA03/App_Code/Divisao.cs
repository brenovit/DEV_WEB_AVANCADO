using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Divisao
/// </summary>
public class Divisao : Operacao
{
    public Divisao()
    {
    }

    public override int handelOperacao(int val1, int val2)
    {
        return Convert.ToInt32(val1 / val2);
    }
}