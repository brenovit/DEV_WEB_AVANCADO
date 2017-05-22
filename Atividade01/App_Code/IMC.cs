using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IMC
/// </summary>
public class IMC
{
    public double Peso { get; set; }
    public double Altura { get; set; }
   
    public IMC() { }

    public IMC (double peso, double altura)
    {
        this.Peso = peso;
        this.Altura = altura;
    }

    public double Calculo()
    {
        double imc = Peso / (Math.Pow(Altura, 2));
        return imc;
    }
}