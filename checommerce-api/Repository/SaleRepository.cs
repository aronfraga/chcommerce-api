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
		
		public List<Venta> GetAllSales() {
			List<Venta> venta = new List<Venta>();
			query = "SELECT * FROM Venta";
			try {
				command.CommandText = query;
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
		
		public void NewSale(List<Producto> producto, int IdUsuario) {
			query = $"INSERT INTO Venta (Comentarios, IdUsuario) VALUES (' ', @idusuario) SELECT @@IDENTITY AS 'Identity'";
			decimal IdVenta = 0;
			ProductSaleRepository productSale = new ProductSaleRepository();
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
				
				productSale.NewProductSale(producto, IdUsuario, (int)IdVenta);
			} catch (Exception ex) {
				throw ex;
			} finally {
				if (connection.State == ConnectionState.Open) {
					connection.Close();
				}
			}
		}

		public void DeleteSale(int id) {
			query = "DELETE FROM Venta WHERE Id=@id";
			ProductSaleRepository productSale = new ProductSaleRepository();
			try {
				if (id == null) throw new Exception("El id del usuario es obligatorio");
				productSale.DeleteProductSale(id);
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
