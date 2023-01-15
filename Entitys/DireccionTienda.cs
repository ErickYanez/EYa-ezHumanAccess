using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class DireccionTienda
    {
        public int IdDireccionTienda { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public Entitys.Colonia Colonia { get; set; }
        public Entitys.Tienda Tienda { get; set; }
        public List<Object> DireccionTiendas { get; set; }
    }
}
