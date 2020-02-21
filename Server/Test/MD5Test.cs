using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test
{
    public class MD5Test
    {
        public void Run()
        {
            Console.WriteLine("正在准备数据...");
            var dt = new DataTable();
            dt.Columns.Add("c1");
            dt.Columns.Add("c2");
            dt.Columns.Add("c3");
            dt.Columns.Add("c4");
            dt.Columns.Add("c5");

            var random = new Random();
            for (int i = 0; i < 1000000; i++)
                dt.Rows.Add(random.Next().ToString(), random.Next().ToString(), random.Next().ToString(), random.Next().ToString(), random.Next().ToString());

            Console.WriteLine($"计算md5开始, 共{dt.Rows.Count}条数据...");
            var watch = Stopwatch.StartNew();
            using (var md5 = MD5.Create())
            {
                var md5s = dt.AsEnumerable().Select(dr => GetMD5(dr.ItemArray, md5)).ToArray();
            }
            watch.Stop();
            Console.WriteLine($"耗时 {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        private string GetMD5(object obj, MD5 md5 = null)
        {
            byte[] objData;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                objData = ms.ToArray();
            }
            byte[] md5bytes;
            if (md5 == null)
                using (md5 = MD5.Create())
                    md5bytes = md5.ComputeHash(objData);
            else
                md5bytes = md5.ComputeHash(objData);
            var str = Convert.ToBase64String(md5bytes);
            return str;
        }
    }
}
