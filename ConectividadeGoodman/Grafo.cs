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


    }
}
