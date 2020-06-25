using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Pedidos
    {
        public int Id_pedido { set; get; }
        public DateTime fecha_generacion { set; get; }
        public DateTime fecha_entrega { set; get; }
        public double total_pedido { set; get; }
        public int status { set; get; }
        public virtual Cliente Cliente { get; set; }

    }
}