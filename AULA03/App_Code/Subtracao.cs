using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subtracao
/// </summary>
public class Subtracao : Operacao
{
    public Subtracao()
    {
    }

    public override int handelOperacao(int val1, int val2)
    {
        return val1 - val2;
    }
}