using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase {

		ProductRepository product = new ProductRepository();

		[HttpGet]
		public IActionResult GetAllSales() {
			return Ok(product.GetProducts());
		}
		
		[HttpGet("{id}")]
		public IActionResult GetSaleById(int id) {
			return Ok(product.GetProduct(id));
		}
		
		[HttpPost]
		public IActionResult Crear([FromBody] Producto producto ) {
			product.PostProduct(producto);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Actualizar(int id, [FromBody] Producto producto) {
			product.PutProduct(producto, id);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Eliminar(int id) {
			product.DeleteProduct(id);
			return Ok();
		}

	}
}
