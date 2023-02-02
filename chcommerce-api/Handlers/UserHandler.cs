using chcommerce_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {

	public class UserHandler {

		public string connectionString = "Server =.\\SQLExpress; Database = SistemaGestion; User ID = aronfraga; Password = 12345678; TrustServerCertificate = True; Trusted_Connection = True; MultipleActiveResultSets = true";

		public List<Usuario> GetUsers() {
			List<Usuario> usuarios = new List<Usuario>();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM Usuario", connection);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
				if (reader.HasRows) {
					while (reader.Read()) {
						Usuario UsuarioTemporal = new Usuario();

						UsuarioTemporal.Id = reader.GetInt64(0);
						UsuarioTemporal.Nombre = reader.GetString(1);
						UsuarioTemporal.Apellido = reader.GetString(2);
						UsuarioTemporal.NombreUsuario = reader.GetString(3);
						UsuarioTemporal.Contraseña = reader.GetString(4);
						UsuarioTemporal.Mail = reader.GetString(5);

						usuarios.Add(UsuarioTemporal);
					}
				}
				return usuarios;
			}
		}

		public Usuario GetUserById(int id) {
			Usuario UsuarioTemporal = new Usuario();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM Usuario WHERE Id=@id", connection);
				query.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					UsuarioTemporal.Id = reader.GetInt64(0);
					UsuarioTemporal.Nombre = reader.GetString(1);
					UsuarioTemporal.Apellido = reader.GetString(2);
					UsuarioTemporal.NombreUsuario = reader.GetString(3);
					UsuarioTemporal.Contraseña = reader.GetString(4);
					UsuarioTemporal.Mail = reader.GetString(5);
				}
			}
			return UsuarioTemporal;
		}

		public Usuario Login(string nombreUsuario, string contraseña) {
			Usuario UsuarioTemporal = new Usuario();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario=@nombreusuario AND Contraseña=@contraseña", connection);
				query.Parameters.AddWithValue("@nombreusuario", nombreUsuario);
				query.Parameters.AddWithValue("@contraseña", contraseña);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					UsuarioTemporal.Id = reader.GetInt64(0);
					UsuarioTemporal.Nombre = reader.GetString(1);
					UsuarioTemporal.Apellido = reader.GetString(2);
					UsuarioTemporal.NombreUsuario = reader.GetString(3);
					UsuarioTemporal.Contraseña = reader.GetString(4);
					UsuarioTemporal.Mail = reader.GetString(5);
				}
			}
			return UsuarioTemporal;
		}

	}
}
