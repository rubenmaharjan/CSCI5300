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

        public Orchestra Read(int id)
        {
            string query = "SELECT * from dbo.Orchestra where ID =" + id +";";
            SqlCommand command = new SqlCommand(query, _conn);
            SqlDataReader reader = command.ExecuteReader();
            Orchestra orchestra = new Orchestra();
            if (reader.Read())
            {
                orchestra.Id = (int)reader["Id"];
                orchestra.Name = reader["Name"] as String;
                orchestra.AddressLine1 = reader["AddressLine1"] as String;
                orchestra.AddressLine2 = reader["AddressLine2"] as String;
                orchestra.City = reader["City"] as String;
                orchestra.State = reader["State"] as String;
                orchestra.ZipCode = reader["ZipCode"] as String;
                orchestra.WebsiteURL = reader["WebsiteURL"] as String;
                reader.Close();
                return orchestra;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public void Create(Orchestra orchestra)
        {
            string query = "INSERT INTO dbo.Orchestra (Name, AddressLine1, AddressLine2, City, State, ZipCode, WebsiteURL) VALUES " + 
                            "(@Name, @AddressLine1, @AddressLine2, @City, @State, @ZipCode, @WebsiteURL);";
            SqlCommand command = new SqlCommand(query, _conn);
            command.Parameters.AddWithValue("@Name", orchestra.Name);
            command.Parameters.AddWithValue("@AddressLine1", orchestra.AddressLine1);
            command.Parameters.AddWithValue("@AddressLine2", orchestra.AddressLine2);
            command.Parameters.AddWithValue("@City", orchestra.City);
            command.Parameters.AddWithValue("@State", orchestra.State);
            command.Parameters.AddWithValue("@ZipCode", orchestra.ZipCode);
            command.Parameters.AddWithValue("@WebsiteURL", orchestra.WebsiteURL);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Record Inserted!");
            } catch (SqlException error)
            {
                Console.WriteLine("Error!!! Details:", error.ToString());
            }
        }
    }
}