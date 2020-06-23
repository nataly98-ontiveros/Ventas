using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Ecommerce.Models
{
    public class Devolucion
    {
               
        public int Id_devolucion { get; set; }
        public int Id_cliente { get; set; }
        public int Id_pedido { get; set; }
        public String Motivos { get; set; }       
        public int status { get; set; }

       
    }
}