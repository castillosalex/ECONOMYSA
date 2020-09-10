using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ClienteE
    {
        public int id_Cliente { get; set; }
        public string nombre { get; set; }
        public string ap_Paterno { get; set; }
        public string ap_Materno { get; set; }
        public int celular { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string documento_Ident { get; set; }
    }
}
