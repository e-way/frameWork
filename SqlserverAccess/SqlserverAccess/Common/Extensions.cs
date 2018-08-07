using SqlserverAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlserverAccess.Common
{
    public static class Extensions
    {
        public static Column[] GetColumnList(this IDataRecord record)
        {
            var result = new Column[record.FieldCount];
            for (int i = 0; i < record.FieldCount; i++)
            {
                var type = record.GetFieldType(i);
                var name = record.GetName(i);

                result[i] = new Column { Name = name, Type = type };
            }
            return result;
        }
    }
}
