using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class Aresta
    {
        public Object element;
        private Vertice vInicial, vFinal;
        private Boolean direcionada;

        public Aresta(Vertice vInicial, Vertice vFinal, object obj, bool direcionada)
        {
            this.element = obj;
            this.vInicial = vInicial;
            this.vFinal = vFinal;
            this.direcionada = direcionada;
        }

        public Vertice verticeInicial()
        {
            return vInicial;
        }

        public Vertice verticeFinal()
        {
            return vFinal;
        }

        public bool Direcionada { get; set; }

    }
}
