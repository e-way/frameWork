using SqlserverAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlserverAccess.Client
{
    public class SqlClient
    {
        public static List<ManagerEmployee> ExecuteStoredProcedure(string procedureName)
        {
            List<ManagerEmployee> managerEmployees = new List<ManagerEmployee>();
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

                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            managerEmployees.Add(GetManagerEmployee(reader));
                        }
                    }
                }
            }
            return managerEmployees;
        }

        private static ManagerEmployee GetManagerEmployee(IDataRecord record)
        {
            return new ManagerEmployee
            {
                RecursionLevel = Convert.ToInt32(record["RecursionLevel"]),
                OrganizationNode = record["OrganizationNode"] as string,
                ManagerFirstName = record["ManagerFirstName"] as string,
                ManagerLastName = record["ManagerLastName"] as string,
                BusinessEntityID = Convert.ToInt32(record["BusinessEntityID"]),
                FirstName = record["FirstName"] as string,
                LastName = record["LastName"] as string
            };
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
