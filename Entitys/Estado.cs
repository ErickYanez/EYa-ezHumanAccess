using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public Entitys.Pais Pais { get; set; }
        public List<Object> Estados { get; set; }
    }
}
