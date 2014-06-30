using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.Entity
{
    public class PromocaoEntity : tbPromoco
    {
        public string nomeCliente { get; set; }
    }
}
