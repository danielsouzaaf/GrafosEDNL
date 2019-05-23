using System;
using System.Collections.Generic;
using System.Text;

namespace Grafos
{
    public class Vertice
    {
        private object element;
        public Vertice(object obj)
        {
            this.element = obj;
        }

        public object Element
        {
            get; set;
        }


    }
}
