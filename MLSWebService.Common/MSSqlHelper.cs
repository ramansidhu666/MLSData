using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace MLSData.Common
{
	public class MSSqlHelper : IDisposable
	{
		private IDbCommand cmd = new SqlCommand();
		private string strConnectionString = "";
		private bool handleErrors = false;
		private string strLastError = "";
		public string CommandText
		{
			get
			{
				return this.cmd.CommandText;
			}
			set
			{
				this.cmd.CommandText = value;
				this.cmd.Parameters.Clear();
			}
		}
		public IDataParameterCollection Parameters
		{
			get
			{
				return this.cmd.Parameters;
			}
		}
		public string ConnectionString
		{
			get
			{
				return this.strConnectionString;
			}
			set
			{
				this.strConnectionString = value;
			}
		}
		public bool HandleExceptions
		{
			get
			{
				return this.handleErrors;
			}
			set
			{
				this.handleErrors = value;
			}
		}
		public string LastError
		{
			get
			{
				return this.strLastError;
			}
		}
		public MSSqlHelper()
		{
            ConnectionStringSettings objConnectionStringSettings = ConfigurationManager.ConnectionStrings["MLSDataConnectionString"];
			this.strConnectionString = objConnectionStringSettings.ConnectionString;
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = this.strConnectionString;
			this.cmd.CommandType = CommandType.StoredProcedure;
			this.cmd.Connection = cnn;
		}
		public IDataReader ExecuteReader()
		{
			IDataReader reader = null;
			try
			{
				this.Open();
				reader = this.cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return reader;
		}
		public IDataReader ExecuteReader(string commandtext)
		{
			IDataReader reader = null;
			try
			{
				this.cmd.CommandText = commandtext;
				reader = this.ExecuteReader();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return reader;
		}
		public object ExecuteScalar()
		{
			object obj = null;
			try
			{
				this.Open();
				obj = this.cmd.ExecuteScalar();
				this.Close();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return obj;
		}
		public object ExecuteScalar(string commandtext)
		{
			object obj = null;
			try
			{
				this.cmd.CommandText = commandtext;
				obj = this.ExecuteScalar();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return obj;
		}
		public int ExecuteNonQuery()
		{
			int i = -1;
			try
			{
				this.Open();
				i = this.cmd.ExecuteNonQuery();
				this.Close();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return i;
		}
		public int ExecuteNonQuery(string commandtext)
		{
			int i = -1;
			try
			{
				this.cmd.CommandText = commandtext;
				this.cmd.CommandType = CommandType.StoredProcedure;
				i = this.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return i;
		}
		public DataSet ExecuteDataSet()
		{
			DataSet ds = null;
			try
			{
				SqlDataAdapter da = new SqlDataAdapter();
				da.SelectCommand = (SqlCommand)this.cmd;
				ds = new DataSet();
				da.Fill(ds);
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return ds;
		}
		public DataSet ExecuteDataSet(string commandtext)
		{
			DataSet ds = null;
			try
			{
				this.cmd.CommandText = commandtext;
				this.cmd.CommandType = CommandType.StoredProcedure;
				ds = this.ExecuteDataSet();
			}
			catch (Exception ex)
			{
				if (!this.handleErrors)
				{
					throw;
				}
				this.strLastError = ex.Message;
			}
			catch
			{
				throw;
			}
			return ds;
		}
		public void AddParameter(string paramname, object paramvalue)
		{
			SqlParameter param = new SqlParameter(paramname, paramvalue);
			this.cmd.Parameters.Add(param);
		}
		public void AddParameter(IDataParameter param)
		{
			this.cmd.Parameters.Add(param);
		}
		private void Open()
		{
			this.cmd.Connection.Open();
		}
		private void Close()
		{
			this.cmd.Connection.Close();
		}
		public void Dispose()
		{
			this.cmd.Dispose();
		}
	}
}
