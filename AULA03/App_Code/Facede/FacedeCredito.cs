using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FacedeCredito
/// </summary>
public class FacedeCredito
{
    private Serasa serasa = new Serasa();
    private SPC spc = new SPC();
    private DataPrev dataPrev = new DataPrev();

    public FacedeCredito()
    {
        
    }

    public string VerificaFinanceiro(Pessoa pessoa, double valor)
    {
        string retorno = "";
        retorno += "<br />" + serasa.estaNoSarasa(pessoa) +
        "<br />" + spc.estaNoSpc(pessoa) +
        "<br />" + dataPrev.possuiLimiteValor(pessoa,valor);
        return retorno;
    }
}