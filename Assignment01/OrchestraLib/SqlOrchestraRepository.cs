using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace OrchestraLib
{
    public class SqlOrchestraRepository : IOrchestraRepository, IDisposable
    {
        private readonly SqlConnection _conn;
        public SqlOrchestraRepository()
        {
            _conn = new SqlConnection(@"Server=127.0.0.1,1433;Database=OrchestraDb;MultipleActiveResultSets=true;User=sa;Password=Password@123;TrustServerCertificate=true;");
            _conn.Open();
        }
        public void Dispose()
        {
            _conn.Close();
        }

        public ICollection<Orchestra> ReadAll()
        {
            string query = "SELECT * from dbo.Orchestra;";
            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();
            ICollection<Orchestra> result = new List<Orchestra>();
            while (reader.Read())
            {
                Orchestra orchestra = new Orchestra(
                    (int)reader["Id"], reader["Name"] as String,
                    reader["AddressLine1"] as String,
                    reader["AddressLine2"] as String,
                    reader["City"] as String,
                    reader["State"] as String,
                    reader["ZipCode"] as String,
                    reader["WebsiteURL"] as String
                    );
                result.Add(orchestra);
            }
            reader.Close();
            return result;
        }
    }
}