using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMC
/// </summary>
public class IMC
{
    public double Altura { get; set; }
    public double Peso { get; set; }

    public double Calcular()
    {        
        double IMC = Peso / (Math.Pow(Altura, 2));
        return IMC;
    }

    public IMC()   {   }

    public IMC(double _altura, double _peso)
    {
        Altura = _altura;
        Peso = _peso;
    }
}