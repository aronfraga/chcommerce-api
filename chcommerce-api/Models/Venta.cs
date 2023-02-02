using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chcommerce_api.Models {
	public class Venta {

		public long Id { get; set; }
		public string Comentario { get; set; }
		public long IdUsuario { get; set; }

	}
}
