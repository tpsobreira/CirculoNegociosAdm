﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.Entity
{
    public class BannerEntity : tbBanner
    {
        public string nomeCliente { get; set; }
    }
}
