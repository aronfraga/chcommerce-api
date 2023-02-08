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
		public void Crear([FromBody] Usuario usuario) {
			user.PostUser(usuario);
		}

		[HttpPut("{id}")]
		public void Actualizar(int id, [FromBody] Usuario usuario) {
			user.PutUser(usuario, id);
		}

		[HttpDelete("{id}")]
		public void Eliminar(int id) {
			user.DeleteUser(id);
		}

	}
}
