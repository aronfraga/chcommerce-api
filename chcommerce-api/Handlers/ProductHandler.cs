using chcommerce_api.Models;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class ProductHandler {

		public string connectionString = "Server =.\\SQLExpress; Database = SistemaGestion; User ID = aronfraga; Password = 12345678; TrustServerCertificate = True; Trusted_Connection = True; MultipleActiveResultSets = true";

		public List<Producto> GetProducts(int id) {
			List<Producto> producto = new List<Producto>();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@id", connection);
				query.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
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
			}
		}

	}
}
