using SqlserverAccess.Common;
using SqlserverAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlserverAccess.Client
{
    public class SqlClient
    {
        public static DataTable ExecuteStoredProcedure(string procedureName)
        {
            DataTable tableValue;
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

                    IDataReader reader;
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data = reader.GetSchemaTable();
                            Console.WriteLine(data.ToList<ManagerEmployee>().ToString());
                            Print(data.ToList<ManagerEmployee>());
                        }
                        tableValue = reader.GetSchemaTable().Clone();
                    }
                }
            }
            return tableValue;
        }

        //public static IEnumerable<T> ExecuteObject<T>(string procedureName)
        //{
        //    List<T> items = new List<T>();
        //    var data = ExecuteStoredProcedure(procedureName); 
        //    foreach (var row in data.Rows)
        //    {
        //        T item = (T)Activator.CreateInstance(typeof(T), row);
        //        items.Add(item);
        //    }
        //    return items;
        //}

      

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

        private static void Print(List<ManagerEmployee>managerEmployees)
        {
            foreach (var managerEmployee in managerEmployees)
            {
                Console.WriteLine(managerEmployee.ToString());
            }
        }
    }
}
