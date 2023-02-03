using chcommerce_api.Data;
using chcommerce_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class UserHandler : DbConnect {

		public List<Usuario> GetUsers() {
			List<Usuario> usuarios = new List<Usuario>();
			query = "SELECT * FROM Usuario";
			try {
				command.CommandText = query;
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					while (reader.Read()) {
						Usuario UsuarioTemporal = new Usuario();

						UsuarioTemporal.Id = reader.GetInt64(0);
						UsuarioTemporal.Nombre = reader.GetString(1);
						UsuarioTemporal.Apellido = reader.GetString(2);
						UsuarioTemporal.NombreUsuario = reader.GetString(3);
						UsuarioTemporal.Contrasena = reader.GetString(4);
						UsuarioTemporal.Mail = reader.GetString(5);

						usuarios.Add(UsuarioTemporal);
					}
				}
				return usuarios;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public Usuario GetUserById(int id) {
			Usuario UsuarioTemporal = new Usuario();
			query = "SELECT * FROM Usuario WHERE Id=@id";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					UsuarioTemporal.Id = reader.GetInt64(0);
					UsuarioTemporal.Nombre = reader.GetString(1);
					UsuarioTemporal.Apellido = reader.GetString(2);
					UsuarioTemporal.NombreUsuario = reader.GetString(3);
					UsuarioTemporal.Contrasena = reader.GetString(4);
					UsuarioTemporal.Mail = reader.GetString(5);
				}
				return UsuarioTemporal;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public Usuario Login(string user, string password) {
			Usuario UsuarioTemporal = new Usuario();
			query = "SELECT * FROM Usuario WHERE NombreUsuario=@user AND Contraseña=@password";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@user", user);
				command.Parameters.AddWithValue("@password", password);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					UsuarioTemporal.Id = reader.GetInt64(0);
					UsuarioTemporal.Nombre = reader.GetString(1);
					UsuarioTemporal.Apellido = reader.GetString(2);
					UsuarioTemporal.NombreUsuario = reader.GetString(3);
					UsuarioTemporal.Contrasena = reader.GetString(4);
					UsuarioTemporal.Mail = reader.GetString(5);
				}
				return UsuarioTemporal;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

	}
}
