using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_RESTFULL.Context;
using WEBAPI_RESTFULL.Entities;

namespace WEBAPI_RESTFULL.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    // public class ProductoController : ControllerBase
    public class ProductoController : Controller
    {
        private AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        // public IEnumerable<string> Get()
        public IEnumerable<Producto> Get()
        {
            // return new string[] { "value1", "value2" };
            return context.Producto.ToList();
        }

        // Visualizar producto por ID
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            var producto = context.Producto.FirstOrDefault(x => x.pro_codigo == id);
            return producto;
        }

        // Metodo POST para la creación de producto
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            // Controlamos ejecución
            try
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return Ok(); // En caso que se agregue exitosamente
            } catch (Exception ex)
            {
                return BadRequest(); // Retornamos en caso que suceda un error
            }
        }
    }
}
