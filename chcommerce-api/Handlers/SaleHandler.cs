using chcommerce_api.Data;
using chcommerce_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Handler {
	public class SaleHandler : DbConnect {

		public List<Venta> GetSalesById(int id) {
			List<Venta> venta = new List<Venta>();
			query = "SELECT * FROM Venta WHERE Venta.IdUsuario=@id";
			try {
				command.CommandText = query;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
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
