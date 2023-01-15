using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Tienda
    {
        public int IdTienda { get; set; }
        public string Sucursal { get; set; }
        public List<Object> Tiendas { get; set; }
        public Entitys.DireccionTienda DireccionTienda { get; set; }
    }
}
