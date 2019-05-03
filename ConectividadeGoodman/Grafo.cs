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

        public void BuscaEmProfundidade(int v, bool[] visitados)
        {
            visitados[v] = true;

            for (int i = 0; i < listasAdjacencias[v].Count; i++)
                if (!visitados[v])
                    BuscaEmProfundidade(i, visitados);
        }

        public bool ehConexo()
        {
            bool[] visitados = new bool[qtdV];
            bool[] visitadosTransposta = new bool[qtdV];

            BuscaEmProfundidade(0, visitados);

            // se não tiver visitado todos os vértices, não é conexo.
            for (int i = 0; i < qtdV; i++)
                if (visitados[i] == false)
                    return false;

            //transposta do grafo pra visitar de novo

            Grafo g = this.GetTransposta();

            g.BuscaEmProfundidade(0, visitadosTransposta);

            // se não tiver visitado todos os vértices na transposta, não é conexo.

            for (int i = 0; i < qtdV; i++)
                if (visitadosTransposta[i] == false)
                    return false;

            return true;



        }





    }
}
