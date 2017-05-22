using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SireneConcreta
/// </summary>
public class SireneConcreta : Sirene
{
    private bool alertaSonoro = false;
    private List<Operario> observadores = new List<Operario>();

    public void alteraAlerta()
    {
        alertaSonoro = !alertaSonoro;
        foreach (Operario ope in observadores)
        {
            Operario o = (Operario)ope;
            o.atualizar(this);
        }
    }

    public bool getAlerta()
    {
        return alertaSonoro;
    }

    public void adicionarObservador(Operario operario)
    {
        observadores.Add(operario);
    }

    public void removerObservador(Operario operario)
    {
        observadores.Remove(operario);
    }
}