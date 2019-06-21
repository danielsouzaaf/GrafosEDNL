using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class TorresDeRadio
    {
        private Grafo grafo;
        private List<Vertice> vertices;
        
        public Dictionary<Vertice, int> resolver()
        {
            //Resolvendo para a América do Sul toda
            List<(int, Vertice)> verticesComGrau = new List<(int, Vertice)>();
            foreach (Vertice v in vertices)
            {
                verticesComGrau.Add((grafo.grau(v), v));
            }
            verticesComGrau.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            Dictionary<Vertice, int> mapaCores = new Dictionary<Vertice, int>();
            int indiceCor = 0;
            for (int i = 0; i < verticesComGrau.Count; i++)
            {
                if (!mapaCores.ContainsKey(verticesComGrau[i].Item2))
                {
                    mapaCores.Add(verticesComGrau[i].Item2, ++indiceCor);
                    for (int j = i + 1; j < verticesComGrau.Count; j++)
                        if (!(grafo.ehAdjacente(verticesComGrau[i].Item2, verticesComGrau[j].Item2)) && !mapaCores.ContainsKey(verticesComGrau[j].Item2))
                        {
                            int ehadjacente = 0;
                            foreach (Vertice v in mapaCores.Keys)
                            {
                                if (grafo.ehAdjacente(verticesComGrau[j].Item2, v) && mapaCores.GetValueOrDefault(v) == indiceCor)
                                ehadjacente = 1;
                            }

                            if (ehadjacente == 0)
                            {
                                mapaCores.Add(verticesComGrau[j].Item2, indiceCor);
                            }

                        }
                            
                }

            }

            return mapaCores;

        }

        public TorresDeRadio()
        {
            grafo = new Grafo();
            grafo.inserirVertice("Brasil");
            grafo.inserirVertice("Argentina");
            grafo.inserirVertice("Uruguai");
            grafo.inserirVertice("Paraguai");
            grafo.inserirVertice("Bolívia");
            grafo.inserirVertice("Peru");
            grafo.inserirVertice("Chile");
            grafo.inserirVertice("Colômbia");
            grafo.inserirVertice("Equador");
            grafo.inserirVertice("Venezuela");
            grafo.inserirVertice("Guiana");
            grafo.inserirVertice("Suriname");
            grafo.inserirVertice("Guiana Francesa");

            Vertice Brasil = new Vertice("Brasil");
            Vertice Argentina = new Vertice("Argentina");
            Vertice Uruguai = new Vertice("Uruguai");
            Vertice Paraguai = new Vertice("Paraguai");
            Vertice Bolivia = new Vertice("Bolívia");
            Vertice Peru = new Vertice("Peru");
            Vertice Chile = new Vertice("Chile");
            Vertice Colombia = new Vertice("Colômbia");
            Vertice Equador = new Vertice("Equador");
            Vertice Venezuela = new Vertice("Venezuela");
            Vertice Guiana = new Vertice("Guiana");
            Vertice Suriname = new Vertice("Suriname");
            Vertice GuianaFrancesa = new Vertice("Guiana Francesa");

            vertices = grafo.getVertices();


            //Brasil e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Uruguai), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Argentina), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Paraguai), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Bolivia), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Peru), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Colombia), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Venezuela), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Guiana), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(Suriname), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Brasil), grafo.AcharIndice(GuianaFrancesa), 0, false);

            //Argentina e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Argentina), grafo.AcharIndice(Uruguai), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Argentina), grafo.AcharIndice(Paraguai), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Argentina), grafo.AcharIndice(Bolivia), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Argentina), grafo.AcharIndice(Chile), 0, false);

            //Paraguai e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Paraguai), grafo.AcharIndice(Bolivia), 0, false);

            //Bolívia e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Bolivia), grafo.AcharIndice(Chile), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Bolivia), grafo.AcharIndice(Peru), 0, false);

            //Colômbia e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Colombia), grafo.AcharIndice(Peru), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Colombia), grafo.AcharIndice(Equador), 0, false);
            grafo.inserirAresta(grafo.AcharIndice(Colombia), grafo.AcharIndice(Venezuela), 0, false);

            //Equador e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Equador), grafo.AcharIndice(Peru), 0, false);

            //Venezuela e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Venezuela), grafo.AcharIndice(Guiana), 0, false);

            //Guiana e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Guiana), grafo.AcharIndice(Suriname), 0, false);

            //Suriname e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Suriname), grafo.AcharIndice(GuianaFrancesa), 0, false);

            //Peru e suas Fronteiras
            grafo.inserirAresta(grafo.AcharIndice(Peru), grafo.AcharIndice(Chile), 0, false);

            grafo.mostrarSoTabela();
            Console.ReadKey();
            
        }

        public void imprimirSolucao(Dictionary<Vertice, int> mapaCores)
        {
            foreach (KeyValuePair<Vertice, int> kvp in mapaCores)
            {
                Console.WriteLine($"Vértice {kvp.Key.element} - Cor: {kvp.Value}");
            }
        }
       
    }
}
