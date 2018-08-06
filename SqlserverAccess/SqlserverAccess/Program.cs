using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SqlserverAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var procedureName = "[dbo].[uspGetManagerEmployees]";
            var connectString = GetConnectStr();
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    connection.Open();

                    var returned = command.Parameters.Add(new SqlParameter("@BusinessEntityID", SqlDbType.Int)
                    {
                        Value = 3
                    });
                    var rowAffacted = command.ExecuteNonQuery();
                    Console.Write(rowAffacted);
                }
            }
        }


        private static string GetConnectStr()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-V4UNJHJ",
                InitialCatalog = "AdventureWorks2017",
                UserID = "sa",
                Password = "sa"
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}
