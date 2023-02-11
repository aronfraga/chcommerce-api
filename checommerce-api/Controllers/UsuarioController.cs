using checommerce_api.Models;
using checommerce_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase {

		UserRepository user = new UserRepository();

		[HttpPost]
		public IActionResult Crear([FromBody] Usuario usuario) {
			user.PostUser(usuario);
			return Ok();
		}
		
		[HttpGet]
		public IActionResult GetAllUsers([FromBody] Login usuario) {
			return Ok(user.Login(usuario));
		}
		
		[HttpGet("{id}")]
		public IActionResult GetUserById(int id) {
			return Ok(user.GetNameById(id));
		}

		[HttpPut("{id}")]
		public IActionResult Actualizar(int id, [FromBody] Usuario usuario) {
			user.PutUser(usuario, id);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Eliminar(int id) {
			user.DeleteUser(id);
			return Ok();
		}

	}
}
