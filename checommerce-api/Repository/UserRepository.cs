using checommerce_api.Data;
using checommerce_api.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace checommerce_api.Repository {
	public class UserRepository : DbConnect {

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
		
		public string GetNameById(int id) {
			query = "SELECT Nombre FROM Usuario WHERE Id=@id";
			string name = String.Empty;
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					reader.Read();
					name = reader.GetString(0);
				}
				return name;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}
		

		public Usuario Login(Login usuario) {
			Usuario UsuarioTemporal = new Usuario();
			query = "SELECT * FROM Usuario WHERE NombreUsuario=@user AND Contraseña=@password";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@user", usuario.NombreUsuario);
				command.Parameters.AddWithValue("@password", usuario.Contrasena);
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

		public void PostUser(Usuario usuario) {
			query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombre, @apellido, @nombreusuario, @contrasena, @mail)";
			try {
				if (usuario.Nombre == null || usuario.Nombre is not String) throw new Exception("El nombre del usuario es obligatorio");
				if (usuario.Apellido == null || usuario.Apellido is not String) throw new Exception("El apellido del usuario es obligatorio");
				if (usuario.NombreUsuario == null || usuario.NombreUsuario is not String) throw new Exception("El nombre de usuario es obligatorio");
				if (usuario.Contrasena == null || usuario.Contrasena is not String) throw new Exception("La contraseña del usuario es obligatorio");
				if (usuario.Mail == null || usuario.Mail is not String) throw new Exception("El mail del usuario es obligatorio");

				command.CommandText = query;
				command.Parameters.AddWithValue("@nombre", usuario.Nombre);
				command.Parameters.AddWithValue("@apellido", usuario.Mail);
				command.Parameters.AddWithValue("@nombreusuario", usuario.NombreUsuario);
				command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
				command.Parameters.AddWithValue("@mail", usuario.Mail);

				connection.Open();
				command.ExecuteNonQuery();

			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public void PutUser(Usuario usuario, int id) {
			query = "UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, NombreUsuario=@nombreusuario, Contraseña=@contrasena, Mail=@mail WHERE Id=@id";
			try {
				if (usuario.Nombre == null || usuario.Nombre is not String) throw new Exception("El nombre del usuario es obligatorio");
				if (usuario.Apellido == null || usuario.Apellido is not String) throw new Exception("El apellido del usuario es obligatorio");
				if (usuario.NombreUsuario == null || usuario.NombreUsuario is not String) throw new Exception("El nombre de usuario es obligatorio");
				if (usuario.Contrasena == null  || usuario.Contrasena is not String) throw new Exception("La contraseña del usuario es obligatorio");
				if (usuario.Mail == null || usuario.Mail is not String ) throw new Exception("El mail del usuario es obligatorio");

				command.CommandText = query;
				command.Parameters.AddWithValue("@nombre", usuario.Nombre);
				command.Parameters.AddWithValue("@apellido", usuario.Apellido);
				command.Parameters.AddWithValue("@nombreusuario", usuario.NombreUsuario);
				command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
				command.Parameters.AddWithValue("@mail", usuario.Mail);
				command.Parameters.AddWithValue("@id", id);

				connection.Open();
				command.ExecuteNonQuery();

			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public void DeleteUser(int id) {
			query = "DELETE FROM Usuario WHERE Id=@id";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);

				connection.Open();
				command.ExecuteNonQuery();

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
