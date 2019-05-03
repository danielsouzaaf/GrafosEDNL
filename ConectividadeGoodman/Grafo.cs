using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Conectividade
{
    class Grafo
    {
        public int qtdV; //quantidade de vértices
        public Dictionary<int, LinkedList<int>> listasAdjacencias;

        public Grafo(int qtdV)
        {
            this.qtdV = qtdV;
            this.listasAdjacencias = new Dictionary<int, LinkedList<int>>(qtdV);

            for (int i = 0; i < qtdV; i++)
                listasAdjacencias[i] = new LinkedList<int>();
        }

        public Grafo GetTransposta()
        {
            Grafo g = new Grafo(qtdV);

            for (int v = 0; v < qtdV; v++)
            {
                for (int i = 0; i < listasAdjacencias[v].Count; i++)
                {
                    g.listasAdjacencias[i].AddLast(v);
                }
            }

            return g;
        }

        public void AdicionarAresta(int vo, int vd)
        {
            listasAdjacencias[vo].AddLast(vd);
        }

        public void BuscaEmProfundidade(int v, bool[] visitados)
        {
            visitados[v] = true;
            LinkedList<int> lista = listasAdjacencias[v];

            foreach (var adj in lista)
            {
                if (!visitados[adj])
                    BuscaEmProfundidade(adj, visitados);
            }
            
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
