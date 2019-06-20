﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class TorresDeRadio
    {
        private Grafo grafo;
        private List<Vertice> vertices;
        
        public void resolver()
        {
            //Resolvendo para a América do Sul toda
            List<(int, Vertice)> verticesComGrau = new List<(int, Vertice)>();
            foreach (Vertice v in vertices)
            {
                verticesComGrau.Add((grafo.grau(v), v));
            }
            verticesComGrau.Sort((x, y) => y.Item1.CompareTo(x.Item1));
        }

        public TorresDeRadio()
        {
            grafo = new Grafo();
            grafo.inserirVertice("B");
            grafo.inserirVertice("A");
            grafo.inserirVertice("U");
            grafo.inserirVertice("P");
            grafo.inserirVertice("Bo");
            grafo.inserirVertice("Pe");
            grafo.inserirVertice("C");
            grafo.inserirVertice("Co");
            grafo.inserirVertice("E");
            grafo.inserirVertice("V");
            grafo.inserirVertice("G");
            grafo.inserirVertice("S");
            grafo.inserirVertice("Gf");

            Vertice Brasil = new Vertice("B");
            Vertice Argentina = new Vertice("A");
            Vertice Uruguai = new Vertice("U");
            Vertice Paraguai = new Vertice("P");
            Vertice Bolivia = new Vertice("Bo");
            Vertice Peru = new Vertice("Pe");
            Vertice Chile = new Vertice("C");
            Vertice Colombia = new Vertice("Co");
            Vertice Equador = new Vertice("E");
            Vertice Venezuela = new Vertice("V");
            Vertice Guiana = new Vertice("G");
            Vertice Suriname = new Vertice("S");
            Vertice GuianaFrancesa = new Vertice("Gf");

            vertices = grafo.getVertices();

            //Brasil e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Uruguai), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Argentina), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Paraguai), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Bolivia), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Peru), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Colombia), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Venezuela), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Guiana), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(Suriname), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Brasil), vertices.IndexOf(GuianaFrancesa), 0, false);

            //Argentina e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Argentina), vertices.IndexOf(Uruguai), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Argentina), vertices.IndexOf(Paraguai), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Argentina), vertices.IndexOf(Bolivia), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Argentina), vertices.IndexOf(Chile), 0, false);

            //Paraguai e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Paraguai), vertices.IndexOf(Bolivia), 0, false);

            //Bolívia e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Bolivia), vertices.IndexOf(Chile), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Bolivia), vertices.IndexOf(Peru), 0, false);

            //Colômbia e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Colombia), vertices.IndexOf(Peru), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Colombia), vertices.IndexOf(Equador), 0, false);
            grafo.inserirAresta(vertices.IndexOf(Colombia), vertices.IndexOf(Venezuela), 0, false);

            //Equador e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Equador), vertices.IndexOf(Peru), 0, false);

            //Venezuela e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Venezuela), vertices.IndexOf(Guiana), 0, false);

            //Guiana e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Guiana), vertices.IndexOf(Suriname), 0, false);

            //Suriname e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Suriname), vertices.IndexOf(GuianaFrancesa), 0, false);

            //Peru e suas Fronteiras
            grafo.inserirAresta(vertices.IndexOf(Peru), vertices.IndexOf(Chile), 0, false);

        }
       
    }
}