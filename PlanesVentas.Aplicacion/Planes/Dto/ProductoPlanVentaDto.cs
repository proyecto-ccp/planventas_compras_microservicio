﻿
using System.Diagnostics.CodeAnalysis;

namespace PlanesVentas.Aplicacion.Planes.Dto
{

    [ExcludeFromCodeCoverage]
    public class ProductoPlanVentaIn
    {
        public int IdProducto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
