using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConectividadeGoodman
{
    class Grafo
    {
        public int qtdV; //quantidade de vértices
        public List<List<int>> listasAdjacencias;

        public Grafo(int qtdV)
        {
            this.qtdV = qtdV;
            var a = new List<int>();
            this.listasAdjacencias = new List<List<int>>();
        }

        public Grafo GetTransposta()
        {
            Grafo g = new Grafo(qtdV);

            for (int v = 0; v < qtdV; v++)
            {
                for (int i = 0; i < listasAdjacencias[v].Count; i++)
                {
                    g.listasAdjacencias[i].Add(v);
                }
            }

            return g;
        }

        public void AdicionarAresta(int vo, int vd)
        {
            listasAdjacencias[vo].Add(vd);
        }



    }
}
