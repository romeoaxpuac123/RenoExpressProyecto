using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models
{
    [MetadataType(typeof(Producto_Sucursal.MetaData))]
    public partial class Producto_Sucursal
    {
        sealed class MetaData
        {
            [Required]
            public int Codigo_Producto;
            [Required]
            public int Codigo_Sucursal;
            [Required]
            public int Cantidad;
            [Required]
            public int Ultima_Cantidad;
            [Required]
            public System.DateTime Fecha_Adquisicion;

        }
    }
}