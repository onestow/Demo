using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChkDetailCompare
{
    public static class Ext
    {
        public static long GetLongHashCode(this DataTable dt, IEnumerable<string> fields)
        {
            long hash = 123456789L * 123456789L;
            foreach (DataRow row in dt.Rows)
                foreach (var colName in fields)
                    hash += row[colName].GetHashCode() * 17 * colName.GetHashCode();
            return hash;
        }

        //拆分排序再组合后传入
        public static long GetLongHashCode(this DataRow row, IEnumerable<string> fields)
        {
            long hash = 123456789L * 123456789L;
            foreach (var colName in fields)
                hash += row[colName].GetHashCode() * 17 * colName.GetHashCode();
            return hash;
        }
    }
}
