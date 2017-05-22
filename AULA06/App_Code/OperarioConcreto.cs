using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OperarioConcreto
/// </summary>
public class OperarioConcreto : Operario
{
    private SireneConcreta objetoObservado;

    public OperarioConcreto(SireneConcreta sireneConcreta)
    {
        this.objetoObservado = sireneConcreta;
        this.objetoObservado.adicionarObservador(this);
    }

    public void atualizar(Sirene sirene)
    {
        if(sirene == objetoObservado)
        {
            System.Diagnostics.Debug.WriteLine("[ATENÇÃO] A sirente mudou para : "+objetoObservado.getAlerta());
        }
    }
}