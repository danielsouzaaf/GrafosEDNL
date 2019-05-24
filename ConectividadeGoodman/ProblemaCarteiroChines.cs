using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    class ProblemaCarteiroChines
    {
        private Dijkstra dijkstra;
        private Dictionary<Vertice, int[]> matrizCusto = new Dictionary<Vertice, int[]>();

        public void Resolver(Grafo grafo)
        {
            List<Vertice> impares = this.Impares(grafo);
            if (impares.Count != 0)
            {
                List<Vertice> cafe = impares;

                foreach (Vertice origem in impares)
                    foreach (Vertice destino in cafe)
                        matrizCusto.Add(origem, Dijkstra.matrizCusto(grafo, grafo.getVertices().IndexOf(origem), grafo.getVertices().Count));

                foreach (KeyValuePair<Vertice, int[]> entrada in matrizCusto)
                {

                }
                  
            }
        }

        public void printSolucao()
        {
            throw new NotImplementedException();
        }

        private List<Vertice> Impares(Grafo g)
        {
            List<Vertice> impares = g.getVertices();
            impares.RemoveAll(vert => g.grau(vert) % 2 != 0);

            return impares;

        }

        
    }
}
