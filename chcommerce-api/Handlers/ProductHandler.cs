using chcommerce_api.Data;
using chcommerce_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class ProductHandler : DbConnect {

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

	}
}
