using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlserverAccess.Model
{
    public class ManagerEmployee
    {
        public int RecursionLevel { get; set; }
        public string OrganizationNode { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public int BusinessEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ManagerEmployee()
        {

        }

        public ManagerEmployee(int recursionLevel, string organizationNode, string managerFirstName, string managerLastName, int businessEntityID, string firstName, string lastName)
        {
            RecursionLevel = recursionLevel;
            OrganizationNode = organizationNode;
            ManagerFirstName = managerFirstName;
            ManagerLastName = managerLastName;
            BusinessEntityID = businessEntityID;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format($"{this.RecursionLevel} {this.OrganizationNode} {this.ManagerFirstName} {this.ManagerLastName} {this.BusinessEntityID} {this.FirstName} {this.LastName}");
        }

       
    }
}
