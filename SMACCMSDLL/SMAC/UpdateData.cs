using SMAC.DataAccess;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SMAC
{
	public class UpdateData
	{
		public static bool Delete(string strTableName, string sqlWhere)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			string commandText = "DELETE FROM [" + strTableName + "] WHERE " + sqlWhere;
			IDbCommand dbCommand = sqlConnection.CreateCommand();
			dbCommand.CommandText = commandText;
			bool result;
			try
			{
				sqlConnection.Open();
				dbCommand.ExecuteNonQuery();
				result = true;
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public static bool Insert(string strTable, Hashtable htFieldValue)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			ICollection keys = htFieldValue.Keys;
			ICollection values = htFieldValue.Values;
			string text = "INSERT INTO [" + strTable + "](";
			int num = 0;
			foreach (string str in keys)
			{
				text = text + ((num > 0) ? ", " : "") + str;
				num++;
			}
			num = 0;
			text += ") values(";
			foreach (string value in values)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					(num > 0) ? ", " : "",
					"@value",
					num
				});
				num++;
			}
			text += ")";
			SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
			num = 0;
			foreach (string value in values)
			{
				sqlCommand.Parameters.AddWithValue("@value" + num, value);
				num++;
			}
			bool result;
			try
			{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = true;
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public static bool Update(string strTable, Hashtable htTable, string whereSql)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			IDictionaryEnumerator enumerator = htTable.GetEnumerator();
			ICollection values = htTable.Values;
			string text = "UPDATE [" + strTable + "] SET ";
			int num = 0;
			while (enumerator.MoveNext())
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					(num > 0) ? ", " : "",
					enumerator.Key,
					"=@value",
					num
				});
				num++;
			}
			if (whereSql != null && 0 < whereSql.Length)
			{
				text = text + " WHERE " + whereSql;
			}
			SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
			num = 0;
			foreach (string value in values)
			{
				sqlCommand.Parameters.AddWithValue("@value" + num, value);
				num++;
			}
			bool result;
			try
			{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = true;
			}
            catch
            {
                result = false;
            }
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public static bool InsertBySql(string sql)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
			bool result;
			try
			{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = true;
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public static bool UpdateOrder(string sql)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
			bool result;
			try
			{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = true;
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}
        public static DataSet ExecStore(string sp, string param)
        {
            return UpdateBySql("EXEC " + sp + " " + param);
        }
		public static bool SetStatus(string _Table, string _Field, string sqlWhere)
		{
			string cmdText = string.Concat(new string[]
			{
				"UPDATE ",
				_Table,
				" SET ",
				_Field,
				" WHERE ",
				sqlWhere
			});
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			bool result;
			try
			{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = true;
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public static int GetTotalRecord(string sql)
		{
			int value = 0;
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
			try
			{
				sqlConnection.Open();
				value = (int)sqlCommand.ExecuteScalar();
			}
			finally
			{
				sqlConnection.Close();
			}
			return Convert.ToInt32(value);
		}

		public static DataSet UpdateBySql(string sql)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(sql, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			try
			{
				sqlDataAdapter.Fill(dataSet);
			}
			finally
			{
				sqlConnection.Close();
			}
			return dataSet;
		}
        //Thaodv modify 11/08/2016
        public static object ExecuteSql(string sql)
        {
            SqlConnection sqlConnection = SQLWorker.CreatedConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            object result;
            try
            {
                sqlConnection.Open();
                result = sqlCommand.ExecuteScalar();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }
        public static string SQLScalar(string sql)
        {
            string result;
            try
            {
                result = UpdateData.ExecuteSql(sql).ToString();
            }
            catch
            {
                result = "";
            }
            return result;
        }
    }
}
