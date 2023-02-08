using checommerce_api.Data;
using checommerce_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace checommerce_api.Repository {
	public class ProductRepository : DbConnect {

		public List<Producto> GetProducts(int id) {
			List<Producto> producto = new List<Producto>();
			query = "SELECT * FROM Producto WHERE IdUsuario=@id";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					while (reader.Read()) {
						Producto ProductoTemporal = new Producto();

						ProductoTemporal.Id = reader.GetInt64(0);
						ProductoTemporal.Descripciones = reader.GetString(1);
						ProductoTemporal.Costo = reader.GetDecimal(2);
						ProductoTemporal.PrecioVenta = reader.GetDecimal(3);
						ProductoTemporal.Stock = reader.GetInt32(4);
						ProductoTemporal.IdUsuario = reader.GetInt64(5);

						producto.Add(ProductoTemporal);
					}
				}
				return producto;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public void PostProduct(Producto producto) {
			query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripciones, @costo, @precioventa, @stock, @idusuario)";
			try {
				if (producto.Descripciones == null || producto.Descripciones is not String) throw new Exception("Descripcion es obligatoria");
				if (producto.Costo == null) throw new Exception("El costo del producto es obligatorio");
				if (producto.PrecioVenta == null) throw new Exception("El precio de venta del producto es obligatorio");
				if (producto.Stock == null) throw new Exception("El stock del producto es obligatorio");
				if (producto.IdUsuario == null) throw new Exception("El id del usuario del producto es obligatorio");

				command.CommandText = query;
				command.Parameters.AddWithValue("@descripciones", producto.Descripciones);
				command.Parameters.AddWithValue("@costo", producto.Costo);
				command.Parameters.AddWithValue("@precioventa", producto.PrecioVenta);
				command.Parameters.AddWithValue("@stock", producto.Stock);
				command.Parameters.AddWithValue("@idusuario", producto.IdUsuario);

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

		public void PutProduct(Producto producto, int id) {
			query = "UPDATE Producto SET Descripciones=@descripciones, Costo=@costo, PrecioVenta=@precioventa, Stock=@stock, IdUsuario=@idusuario WHERE Id=@id";
			try {
				if (producto.Descripciones == null || producto.Descripciones is not String) throw new Exception("Descripcion es obligatoria");
				if (producto.Costo == null) throw new Exception("El costo del producto es obligatorio");
				if (producto.PrecioVenta == null) throw new Exception("El precio de venta del producto es obligatorio");
				if (producto.Stock == null) throw new Exception("El stock del producto es obligatorio");
				if (producto.IdUsuario == null) throw new Exception("El id del usuario del producto es obligatorio");

				command.CommandText = query;
				command.Parameters.AddWithValue("@descripciones", producto.Descripciones);
				command.Parameters.AddWithValue("@costo", producto.Costo);
				command.Parameters.AddWithValue("@precioventa", producto.PrecioVenta);
				command.Parameters.AddWithValue("@stock", producto.Stock);
				command.Parameters.AddWithValue("@idusuario", producto.IdUsuario);
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

		public void DeleteProduct(int id) {
			query = "DELETE FROM Producto WHERE Id=@id";
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
