using System;
using System.Collections.Generic;
using System.Text;

namespace Conectividade
{
    public class Aresta
    {
        private Object element;
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

    }
}
