using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models
{
    [MetadataType(typeof(Cliente.MetaData))]
    public partial class Cliente
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