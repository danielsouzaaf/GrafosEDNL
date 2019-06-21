using System;
using System.Collections.Generic;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            TorresDeRadio torre = new TorresDeRadio();
            Dictionary<Vertice, int> resolvida = torre.resolver();
            torre.imprimirSolucao(resolvida);
            Console.ReadLine();
        }
    }
}
