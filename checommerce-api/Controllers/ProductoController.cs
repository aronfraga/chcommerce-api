using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase {

		ProductRepository product = new ProductRepository();

		[HttpPost]
		public void Crear([FromBody] Producto producto ) {
			product.PostProduct(producto);
		}

		[HttpPut("{id}")]
		public void Actualizar(int id, [FromBody] Producto producto) {
			product.PutProduct(producto, id);
		}

		[HttpDelete("{id}")]
		public void Eliminar(int id) {
			product.DeleteProduct(id);
		}

	}
}
