using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoVendidoController : ControllerBase {

		ProductSaleRepository productSaleRepository = new ProductSaleRepository();

		[HttpPost("{idusuario}")]
		public void NuevaVenta(int idusuario, [FromBody] List<Producto> producto) {
			productSaleRepository.NewProductSale(producto, idusuario);
		}


	}
}
