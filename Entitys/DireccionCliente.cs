using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class DireccionCliente
    {
        public int IdDireccionCliente { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public Entitys.Colonia Colonia { get; set; }
        public Entitys.Cliente Cliente { get; set; }
        public List<Object> DireccionClientes { get; set; }
    }
}
