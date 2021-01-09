using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models
{
    [MetadataType(typeof(Sucursal.MetaData))]
    public partial class Sucursal
    {
        sealed class MetaData
        {
            [Required]
            public string Nombre;
            [Required]
            public string Direccion;

        }
    }
}