using SqlserverAccess.Common;
using SqlserverAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlserverAccess.Client
{
    public class SqlClient
    {
        public static List<T> ExecuteStoredProcedure<T>(string procedureName, List<Parameter>parameters)
        {
            List<T> managerEmployees = new List<T>();
            var connectString = GetConnectStr();
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    connection.Open();
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(parameter.Name, parameter.Type)
                        {
                            Value = parameter.Value
                        });
                    }

                    var rowAffacted = command.ExecuteNonQuery();
                    //Console.Write(rowAffacted);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            managerEmployees.Add(GetEntity<T>(reader));
                        }
                    }
                }
            }
            return managerEmployees;
        }

        private static T GetEntity<T>(IDataRecord record)
        {
            var columnNames = record.GetColumnNames();
            var obj = Initialize<T>(record, record.GetColumnList());
            return obj; 
        }

        private static T Initialize<T>(IDataRecord record, params Column[] columns)
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            for (int i = 0; i < columns.Length; i++)
            {
                var name = columns[i].Name;
                var type = columns[i].Type;
                var value = Convert.ChangeType(record[name], type);
      
                var tp = obj.GetType();
                foreach (var propInfo in tp.GetProperties())
                {
                    if (propInfo.Name == name)
                    {
                        propInfo.SetValue(obj, value, null);
                    }
                }
            }
            return obj;
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
