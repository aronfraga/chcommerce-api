using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoVendidoController : ControllerBase {
		
		private ProductSaleRepository productSaleRepository = new ProductSaleRepository();

		[HttpGet]
		public IActionResult GetAllProductSales() {
			return Ok(productSaleRepository.GetProductSales());
		}

	}
}
