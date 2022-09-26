using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // metodo PUT para la actualización de registro
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Producto producto)
        {
            // Validamos si el id enviado existe en la entidad Producto
            if(producto.pro_codigo == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            } else
            {
                // En caso que suceda que no exista el ID de actualización
                return BadRequest();
            }
            
        }

        // metodo DELETE para eliminación de registros
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            // Verificamos si ID existe en objeto producto
            var producto = context.Producto.FirstOrDefault(p => p.pro_codigo == id);

            // Validamos obj producto
            if(producto != null)
            {
                // En caso que existan registros, eliminamos
                context.Producto.Remove(producto);
                context.SaveChanges();
                return Ok();
            } else
            {
                // En caso que no existan registros.
                return BadRequest();
            }
        }
    }
}
