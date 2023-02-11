using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class VentaController : ControllerBase {
		
		SaleRepository saleRepository = new SaleRepository();
		
		[HttpGet("{IdUsuario}")]
		public IActionResult GetAllSalesById(int IdUsuario) {
			return Ok(saleRepository.GetSalesById(IdUsuario));
		}
		
		[HttpGet]
		public IActionResult GetAllSales() {
			return Ok(saleRepository.GetAllSales());
		}
		
		[HttpPost("{idusuario}")]
		public IActionResult NewSale(int idusuario, [FromBody] List<Producto> producto) {
			saleRepository.NewSale(producto, idusuario);
			return Ok();
		}
		
		[HttpDelete("{id}")]
		public IActionResult DeleteSale(int id) {
			saleRepository.DeleteSale(id);
			return Ok();
		}

	}
}
