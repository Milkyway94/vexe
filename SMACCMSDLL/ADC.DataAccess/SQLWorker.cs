using SMAC;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SMAC.DataAccess
{
	public class SQLWorker
	{
		public static SqlConnection CreatedConnection()
		{
			DefaultWeb.CheckWeb();
			return new SqlConnection(ConfigurationSettings.AppSettings["strConn"]);
		}
	}
}
