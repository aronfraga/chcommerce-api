namespace checommerce_api.Models {
	public class Venta {

		public long Id { get; set; }
		public string Comentario { get; set; } = String.Empty;
		public long IdUsuario { get; set; }

	}
}
