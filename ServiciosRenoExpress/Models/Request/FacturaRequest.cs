﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models.Request
{
    public class FacturaRequest
    {
        public int Codigo_Cliente;
        public int Codigo_Producto;
        public int Codigo_Sucursal;
        public int Cantidad;
    }
}

