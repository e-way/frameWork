using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SqlserverAccess.Client;
using SqlserverAccess.Model;
using System.Collections;

namespace SqlserverAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var procedureName = "[dbo].[uspGetManagerEmployees]";
            var parameter = new Parameter
            {
                Name = "@BusinessEntityID",
                Type = SqlDbType.Int,
                Value = 3
            };

            List<Parameter> parameters = new List<Parameter>
            {
                parameter
            };

            var data = SqlClient.ExecuteStoredProcedure<ManagerEmployee>(procedureName, parameters);
            Print(data);
        }

        private static void Print(List<ManagerEmployee> managerEmployees)
        {
            foreach (var managerEmployee in managerEmployees)
            {
                Console.WriteLine(managerEmployee.ToString());
            }
        }

    }
}
