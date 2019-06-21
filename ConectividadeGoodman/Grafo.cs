using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Grafos
{
    public class Grafo
    {
        List<Vertice> vertices = new List<Vertice>();
        List<Aresta> arestas = new List<Aresta>();
        List<Aresta>[,] tabela = new List<Aresta>[0, 0];

        public void inserirVertice(object obj)
        {
            Vertice v = new Vertice(obj);
            vertices.Add(v);
            redimensionarTabela();
        }

        public List<Vertice> getVertices()
        {
            return this.vertices;
        }

        private void redimensionarTabela()
        {
            List<Aresta>[,] tabelaNova = new List<Aresta>[vertices.Count, vertices.Count];
            for (int i = 0; i < tabela.GetLength(0); i++)
                for (int j = 0; j < tabela.GetLength(1); j++)
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

        public Aresta menorAresta(Vertice v, Vertice w)
        {
            if (this.ehAdjacente(v, w))
                return tabela[vertices.IndexOf(v), vertices.IndexOf(w)].OrderByDescending(a => a.element).First();
            throw new Exception("Não existe uma aresta entre os vértices!");
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
            return vertices.SingleOrDefault(v => v.element == obj);
        }

        public Aresta acharAresta(object obj)
        {
            return arestas.SingleOrDefault(a => a.element == obj);
        }

        public void substituir(Vertice v, object x)
        {
            v.element = x;
        }

        public void substituir(Aresta e, object x)
        {
            e.element = x;
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

            return v.element;
        }

        public int grau(Vertice v)
        {
            int g = 0;
            int indice = vertices.IndexOf(v);
            for (int i = 0; i < vertices.Count; i++)
                if (tabela[indice, i] != null)
                    g += tabela[indice, i].Count;

            return g;
        }

        public object removerAresta(Aresta a)
        {
            arestas.Remove(a);
            int indiceInicial = vertices.IndexOf(a.verticeInicial()), indiceFinal = vertices.IndexOf(a.verticeFinal());
            tabela[indiceInicial, indiceFinal].Remove(a);
            if (!a.Direcionada)
                tabela[indiceFinal, indiceInicial].Remove(a);

            return a.element;
        }
        /*  Peguei de Israel */
        public void mostrar()
        {
            Console.WriteLine("Tabela: ");
            Console.Write("   |");
            for (int i = 0; i < vertices.Count; i++)
                Console.Write(" v" + vertices.ElementAt(i).element + "|");
            Console.WriteLine();
            for (int i = 0; i < vertices.Count; i++)
            {
                Console.Write("|v" + vertices.ElementAt(i).element);
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (tabela[i, j] == null)
                        Console.Write("| 0 ");
                    else
                        Console.Write("| " + tabela[i, j].Count + " ");
                }
                Console.WriteLine("|");
            }

        }

        public void mostrarSoTabela()
        {
            int rowLength = tabela.GetLength(0);
            int colLength = tabela.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (tabela[i, j] == null)
                        Console.Write(string.Format("0 "));
                    else
                        Console.Write(string.Format("{0} ", tabela[i, j].Count));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

        public int AcharIndice(Vertice v)
        {
            return vertices.FindIndex(r => r.element == v.element);
        }

    }
}
