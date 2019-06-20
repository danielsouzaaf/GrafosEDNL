namespace Grafos
{
    internal class Dijkstra
    {
        private static int DistanciaMinima(int[] distancia, bool[] visitados, int quantidadeVertices)
        {
            int min = int.MaxValue;
            int menorIndice = 0;

            for (int v = 0; v < quantidadeVertices; v++)
                if (visitados[v] == false && distancia[v] <= min)
                {
                    min = distancia[v];
                    menorIndice = v;
                }

            return menorIndice;
        }

        public static int[] matrizCusto(Grafo g, int origem, int quantidadeVertices)
        {
            int[] distancia = new int[quantidadeVertices];
            bool[] visitados = new bool[quantidadeVertices];

            for (int i = 0; i < quantidadeVertices; i++)
            {
                distancia[i] = int.MaxValue;
                visitados[i] = false;
            }

            distancia[origem] = 0;

            for (int i = 0; i < quantidadeVertices - 1; i++)
            {
                int u = DistanciaMinima(distancia, visitados, quantidadeVertices);
                visitados[u] = true;

                for (int j = 0; j < quantidadeVertices; j++)
                {
                    //se o vértice atual ainda não foi visitado
                    //se existir um custo entre o índice do vértice de menor custo e o vertice atual
                    //se a distância não for infinita(for possível chegar nele pelos caminhos feitos até agora)
                    /*se a soma da distância entre a distância do vértice de menor custo e o custo entre o vértice de menor custo e o vértice atual 
                     * for menor que a distância entre a origem e o vértice atual
                     * */
                    if (!visitados[j]
                        && g.ehAdjacente(g.acharVertice(u), g.acharVertice(j))
                        && distancia[u] != int.MaxValue
                        && distancia[u] + (int)(g.menorAresta(g.acharVertice(u), g.acharVertice(j)).element) > distancia[j]
                        )
                        distancia[j] = distancia[u] + (int)(g.menorAresta(g.acharVertice(u), g.acharVertice(j)).element);
                }
            }

            return distancia;
        }
    }
}