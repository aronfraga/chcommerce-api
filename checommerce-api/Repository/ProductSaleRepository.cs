using checommerce_api.Data;
using checommerce_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace checommerce_api.Repository {
	public class ProductSaleRepository : DbConnect {

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

		public void NewProductSale(List<Producto> producto, int IdUsuario) {
			query = "INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@stock, @idproducto, @idventa)";
			SaleRepository sale = new SaleRepository();
			try {
				int idVenta = (int)sale.NewSale(IdUsuario);
				command.CommandText = query;
				connection.Open();

				foreach (var item in producto) {
					command.Parameters.AddWithValue("@idusuario", IdUsuario);
					command.Parameters.AddWithValue("@stock", item.Stock);
					command.Parameters.AddWithValue("@idproducto", item.Id);
					command.Parameters.AddWithValue("@idventa", idVenta);
		
					sale.StockChange(item.Stock, item.Id);
					command.ExecuteNonQuery();
					command.Parameters.Clear();
				}

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
