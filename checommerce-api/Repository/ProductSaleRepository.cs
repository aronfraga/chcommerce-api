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
			sale.NewSale(IdUsuario);
			try {

				//if (producto.Descripciones == null || producto.Descripciones is not String) throw new Exception("Descripcion es obligatoria");
				//if (producto.Costo == null) throw new Exception("El costo del producto es obligatorio");
				//if (producto.PrecioVenta == null) throw new Exception("El precio de venta del producto es obligatorio");
				//if (producto.Stock == null) throw new Exception("El stock del producto es obligatorio");
				//if (producto.IdUsuario == null) throw new Exception("El id del usuario del producto es obligatorio");
				
				connection.Open();

				foreach (var item in producto) {
					command.CommandText = query;
					command.Parameters.Clear();
					command.Parameters.AddWithValue("@idusuario", IdUsuario);
					command.Parameters.AddWithValue("@stock", item.Stock);
					command.Parameters.AddWithValue("@idproducto", item.Id);
					command.Parameters.AddWithValue("@idventa", IdUsuario);
					command.ExecuteNonQuery();
					
					sale.StockChange(item.Stock, item.Id);
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
