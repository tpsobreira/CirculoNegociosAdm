using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.Entity
{
    public class BannerBuscaEntity : tbBannerBusca
    {
        public string nomeCliente { get; set; }
        public string nomeCategoria { get; set; }
    }
}
