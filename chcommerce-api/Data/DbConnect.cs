using System.Data;
using System.Data.SqlClient;

namespace chcommerce_api.Data {
	public class DbConnect {

		protected SqlConnection connection = new SqlConnection();
		protected SqlCommand command = new SqlCommand();
		protected string query;
		private protected string connectionstring = "Server =.\\SQLExpress; Database = SistemaGestion; User ID = aronfraga; Password = 12345678; TrustServerCertificate = True; Trusted_Connection = True; MultipleActiveResultSets = true";

		public DbConnect() {
			connection.ConnectionString = connectionstring;
			command.Connection = connection;
			command.CommandType = CommandType.Text;
		}

	}
}


