using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class ArticuloTienda
    {
        public int IdArticuloTienda { get; set; }
        public Entitys.Articulo Articulo { get; set; }
        public Entitys.Tienda Tienda { get; set; }
        public string Fecha { get; set; }
        public List<Object> ArticuloTiendas { get; set; }
    }
}
