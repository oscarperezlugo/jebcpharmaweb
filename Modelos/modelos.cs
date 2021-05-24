using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Modelos
{
    public class modelos
    {
        public IList<Linea> Lineas { get; set; }
        public class Linea
        {

            public string Nombre { get; set; }
            public double Precio { get; set; }
        }
    }
    
}