using System;
using System.Collections.Generic;
using System.Text;

namespace Conectividade
{
    public class Aresta
    {
        private Object element;
        private Vertice v1, v2;
        private Boolean direcionada;

        public Aresta(Vertice v1, Vertice v2, object obj, bool direcionada)
        {
            this.element = obj;
            this.v1 = v1;
            this.v2 = v2;
            this.direcionada = direcionada;
        }

    }
}
