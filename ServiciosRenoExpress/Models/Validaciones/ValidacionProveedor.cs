using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models
{
    [MetadataType(typeof(Proveedor.MetaData))]
    public partial class Proveedor
    {
        sealed class MetaData
        {
            [Required]
            public string Nombre;
            [Required]
            public string NIT;
            [Required]
            public string Direccion;

        }
    }
}