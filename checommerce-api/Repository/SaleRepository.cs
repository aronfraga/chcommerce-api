using checommerce_api.Data;
using checommerce_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace checommerce_api.Repository {
	public class SaleRepository : DbConnect {

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

		public decimal NewSale(int IdUsuario) {
			query = $"INSERT INTO Venta (IdUsuario) VALUES (@idusuario) SELECT @@IDENTITY AS 'Identity'";
			decimal IdVenta = 0;
			try {
				if (IdUsuario == null) throw new Exception("El id del usuario es obligatorio");

				command.CommandText = query;
				command.Parameters.AddWithValue("@idusuario", IdUsuario);
				connection.Open();

				SqlDataReader reader = command.ExecuteReader();
				if(reader.HasRows) {
					reader.Read();
					IdVenta = reader.GetDecimal(0);
				}
				command.Parameters.Clear();

				return IdVenta;
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public void StockChange(int Stock, long IdProducto) {
			query = "UPDATE Producto SET Stock=Stock-@stock WHERE Id=@id";
			try {
				command.Parameters.Clear();
				command.CommandText = query;
				command.Parameters.AddWithValue("@stock", Stock);
				command.Parameters.AddWithValue("@id", IdProducto);

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
