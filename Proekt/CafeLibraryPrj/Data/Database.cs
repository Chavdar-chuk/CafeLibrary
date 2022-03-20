using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CafeLibraryPrj.Data
{
	public static class Database
	{
		private static string connectionString = "Server=DESKTOP-KS8FQ5B\\SERVERNEW;Database=CafeLibrary;Integrated Security=true;";
		public static SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}
	}
}
