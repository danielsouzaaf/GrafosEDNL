using System;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {

            Grafo g1 = new Grafo(5);
            g1.AdicionarAresta(0, 1);
            g1.AdicionarAresta(1, 2);
            g1.AdicionarAresta(2, 3);
            g1.AdicionarAresta(3, 0);
            g1.AdicionarAresta(2, 4);
            g1.AdicionarAresta(4, 2);
            if (g1.ehConexo())
                Console.WriteLine("É conexo!\n");
            else
                Console.WriteLine("Não é conexo!\n");

            Grafo g2 = new Grafo(4);
            g2.AdicionarAresta(0, 1);
            g2.AdicionarAresta(1, 2);
            g2.AdicionarAresta(2, 3);
            if (g2.ehConexo())
                Console.WriteLine("É conexo!\n");
            else
                Console.WriteLine("Não é conexo!\n");

            Console.ReadLine();
        }
    }
}
