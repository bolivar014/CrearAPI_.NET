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

        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            var producto = context.Producto.FirstOrDefault(x => x.pro_codigo == id);
            return producto;
        }
    }
}
