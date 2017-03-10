using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Essa é uma classe singleton unica
/// </summary>
public class Unica
{
    /// <summary>
    /// Esse é o nome da classe singleton unica
    /// </summary>
    public string Nome { get; set; }
    public static Unica instance;
    private Unica() { }
    
    public static Unica Instance
    {
        get {
            if (instance == null)
                lock(typeof(Unica))
                    instance = new Unica();
            return instance;
        }
    }
}