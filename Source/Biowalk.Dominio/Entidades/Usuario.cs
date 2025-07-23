using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Entidades
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public Guid IdSetor { get; set; }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

    }
}
