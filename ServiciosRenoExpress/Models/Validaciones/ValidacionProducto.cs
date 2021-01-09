using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosRenoExpress.Models
{
    [MetadataType(typeof(Producto.MetaData))]
    public partial class Producto
    {
        sealed class MetaData
        {
            [Required]
            public string Nombre;
            [Required]
            public string Marca;
            [Required]
            public string Descripcion;
            [Required]
            public string Categoria;
            [Required]
            public decimal Precio_Venta;
            [Required]
            public int Codigo_Proveedor;

        }
    }
}