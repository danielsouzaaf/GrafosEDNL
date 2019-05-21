using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Conectividade
{
    public class Grafo
    {
        List<Vertice> vertices = new List<Vertice>();
        List<Aresta> arestas = new List<Aresta>();
        List<Aresta>[,] tabela = new List<Aresta>[0,0];

        public void inserirVertice(object obj)
        {
            Vertice v = new Vertice(obj);
            vertices.Add(v);
            redimensionarTabela();
        }

        private void redimensionarTabela()
        {
            List<Aresta>[,] tabelaNova = new List<Aresta>[vertices.Count, vertices.Count];
            for (int i = 0; i < tabela.Length; i++)
                for (int j = 0; j < tabela.Length; j++)
                    tabelaNova[i, j] = tabela[i, j];

            tabela = tabelaNova;
        }

        public int ordem()
        {
            return vertices.Count;
        }

        public Vertice[] verticesFinais(Aresta a)
        {
            return new Vertice[] { a.verticeInicial(), a.verticeFinal() };
        }

        public Vertice oposto(Vertice v, Aresta a)
        {
            return a.verticeInicial() == v ? a.verticeFinal() : (a.verticeFinal() == v ? a.verticeInicial() : throw new Exception("Nenhum dos dois vértices é um vértice da aresta!"));
        }

        public bool ehAdjacente(Vertice v, Vertice w)
        {
            return tabela[vertices.IndexOf(v), vertices.IndexOf(w)] != null;
        }

        public void inserirAresta(int v, int w, object obj, bool direcionada)
        {
            Aresta a = new Aresta(vertices.ElementAt(v), vertices.ElementAt(w), obj, direcionada);
            if (tabela[v, w] == null)
            {
                tabela[v, w] = new List<Aresta>();
                if (!direcionada)
                    tabela[w, v] = new List<Aresta>();
            }
            tabela[v, w].Add(a);
            if (!direcionada)
                tabela[w, v].Add(a);

            arestas.Add(a);
        }

        public Vertice acharVertice(object obj)
        {
            return vertices.SingleOrDefault(v => v.Element == obj);
        }

        public Aresta acharAresta(object obj)
        {
            return arestas.SingleOrDefault(a => a.Element == obj);
        }

        public void substituir(Vertice v, object x)
        {
            v.Element = x;
        }

        public void substituir(Aresta e, object x)
        {
            e.Element = x;
        }

        public object removerVertice(Vertice v)
        {
            List<Aresta>[,] tabelaNova = new List<Aresta>[vertices.Count - 1, vertices.Count - 1];
            int i = 0, proximoI = 0;
            int indice = vertices.IndexOf(v);
            while (i < vertices.Count - 1)
            {
                int j = 0, proximoJ = 0;
                if (i == indice)
                    proximoI++;
                while (j < vertices.Count - 1)
                {
                    if (j == indice)
                        proximoJ++;
                    tabelaNova[i, j++] = tabela[proximoI, proximoJ++];
                }
                i++;
                proximoI++;
            }

            tabela = tabelaNova;
            vertices.Remove(v);

            return v.Element;
        }

        public object removerAresta(Aresta a)
        {
            arestas.Remove(a);
            int indiceInicial = vertices.IndexOf(a.verticeInicial()), indiceFinal = vertices.IndexOf(a.verticeFinal());
            tabela[indiceInicial, indiceFinal].Remove(a);
            if (!a.Direcionada)
                tabela[indiceFinal, indiceInicial].Remove(a);

            return a.Element;
        }
        /*  Peguei de Israel */
        public void mostrar()
        {
            Console.WriteLine("Tabela: ");
            Console.WriteLine("   |");
            for(int i = 0; i < vertices.Count; i++)
                Console.Write(" v"+vertices.ElementAt(i).Element+"|");
            Console.WriteLine();
            for (int i = 0; i < vertices.Count; i++)
            {
                Console.Write("|v"+vertices.ElementAt(i).Element);
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (tabela[i, j] == null)
                        Console.Write("| 0 ");
                    else
                        Console.Write("| "+tabela[i,j].Count + " ");
                }
                Console.WriteLine("|");
        }
    }
}
