using chcommerce_api.Models;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class ProductSaleHandler {

		public string connectionString = "Server =.\\SQLExpress; Database = SistemaGestion; User ID = aronfraga; Password = 12345678; TrustServerCertificate = True; Trusted_Connection = True; MultipleActiveResultSets = true";

		public List<Producto> GetProductSales(int id) {
			List<Producto> producto = new List<Producto>();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM ProductoVendido PV INNER JOIN Producto P ON PV.IdProducto = P.Id WHERE P.Id=@id", connection);
				query.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
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
			}
		}

	}
}
