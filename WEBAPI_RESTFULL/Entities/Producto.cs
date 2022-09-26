using System.ComponentModel.DataAnnotations;

namespace WEBAPI_RESTFULL.Entities
{
    public class Producto
    {
        [Key]
        public string pro_codigo { get; set; }
        public string pro_nombre { get; set; }
        public string pro_descripcion { get; set; }
        public decimal pro_precio { get; set; }
    }
}
