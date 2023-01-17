using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public List<Object> Articulos { get; set; }
        public Entitys.Tienda Tienda { get; set; }
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }
    }
}
