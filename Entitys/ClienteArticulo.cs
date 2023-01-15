using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class ClienteArticulo
    {
        public int IdClienteArticulo { get; set; }
        public Entitys.Cliente Cliente { get; set; }
        public Entitys.Articulo Articulo { get; set; }
        public string Fecha { get; set; }
        public List<Object> ClienteArticulos { get; set; }
    }
}
