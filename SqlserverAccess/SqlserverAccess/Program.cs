using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SqlserverAccess.Client;
using SqlserverAccess.Model;
using SqlserverAccess.Common;

namespace SqlserverAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var procedureName = "[dbo].[uspGetManagerEmployees]";
            var parameter = new SqlParameter("@BusinessEntityID", SqlDbType.Int);
            var data = SqlClient.ExecuteStoredProcedure(procedureName);
  
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
