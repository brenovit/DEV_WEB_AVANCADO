using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Opercao
/// </summary>
public abstract class Operacao
{
    public Operacao()
    {
        
    }

    public abstract int handelOperacao(int val1, int val2);
    /// <summary>
    /// Método que faz calculos
    /// </summary>
    /// <param name="val1">Valor inteiro</param>
    /// <param name="val2">Valor inteiro</param>
    /// <returns>Retorna o resultado do Calculo feito</returns>
    public int EfetuaOperacao(int val1, int val2)
    {
        int result = handelOperacao(val1, val2);
        return result;
    }
}