using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface Sirene
{
    void adicionarObservador(Operario operario);
    void removerObservador(Operario operario);
}