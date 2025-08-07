using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Usuario
    {
        public Guid idUsuario { get; set; }
        public Guid idSetor { get; set; }

        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

    }
}
