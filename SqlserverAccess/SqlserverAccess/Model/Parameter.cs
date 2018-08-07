using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlserverAccess.Model
{
    public class Parameter
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }
        public dynamic Value { get; set; }
    }
}
