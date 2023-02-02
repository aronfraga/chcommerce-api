using chcommerce_api.Models;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class SaleHandler {

		public string connectionString = "Server =.\\SQLExpress; Database = SistemaGestion; User ID = aronfraga; Password = 12345678; TrustServerCertificate = True; Trusted_Connection = True; MultipleActiveResultSets = true";

		public List<Venta> GetSalesById(int id) {
			List<Venta> venta = new List<Venta>();
			using (SqlConnection connection = new SqlConnection(connectionString)) {

				SqlCommand query = new SqlCommand("SELECT * FROM Venta WHERE Venta.IdUsuario=@id", connection);
				query.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = query.ExecuteReader();
				if (reader.HasRows) {
					while (reader.Read()) {
						Venta VentaTemporal = new Venta();

						VentaTemporal.Id = reader.GetInt64(0);
						VentaTemporal.Comentario = reader.GetString(1);
						VentaTemporal.IdUsuario = reader.GetInt64(2);

						venta.Add(VentaTemporal);
					}
				}
				return venta;
			}
		}

	}
}
