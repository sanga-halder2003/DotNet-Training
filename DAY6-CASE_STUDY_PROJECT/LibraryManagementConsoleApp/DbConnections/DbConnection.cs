using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System.DbConnections
{
    public class DbConnection
    {
        private readonly string connectionString =
            "Server= localhost\\SQLEXPRESS;Database=LibraryManagementSystem;Trusted_Connection=True;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
