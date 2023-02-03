using chcommerce_api.Data;
using chcommerce_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class ProductSaleHandler : DbConnect {

		public List<Producto> GetProductSales(int id) {
			List<Producto> producto = new List<Producto>();
			query = "SELECT * FROM ProductoVendido PV INNER JOIN Producto P ON PV.IdProducto = P.Id WHERE P.Id=@id";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows) {
					while (reader.Read()) {
						Producto ProductoTemporal = new Producto();

						ProductoTemporal.Id = reader.GetInt64(4);
						ProductoTemporal.Descripciones = reader.GetString(5);
						ProductoTemporal.Costo = reader.GetDecimal(6);
						ProductoTemporal.PrecioVenta = reader.GetDecimal(7);
						ProductoTemporal.Stock = reader.GetInt32(8);
						ProductoTemporal.IdUsuario = reader.GetInt64(9);

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
