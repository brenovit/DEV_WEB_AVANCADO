using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

delegate int AlteraNumero(int n);

public class TesteDelegate
{    
    static int num = 10;
    
    public TesteDelegate()
    {
    }

    public static int somatorio(int valor)
    {
        return num += valor;         
    }

    public static int produtorio(int valor)
    {
        return num *= valor;
    }

    public int getNum()
    {
        AlteraNumero n1 = new AlteraNumero(somatorio);
        AlteraNumero n2 = new AlteraNumero(produtorio);
        
        n1(25);
        n2(5);

        return num;
    }
        
}