using System;
using System.Data.SqlClient;

namespace Inter2.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection connection;

        public Data()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=OrcamentoDigital;
                                Integrated Security=true";
        
                                // User Id=sa; Password=dba;

            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}