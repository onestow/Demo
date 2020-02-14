using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ChkDetailCompare
{
    public class GzipHelper
    {
        public static byte[] ToByte(object obj)
        {
            //return Encoding.UTF8.GetBytes(obj as string);
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                var objData = ms.ToArray();
                return objData;
            }
        }

        public static object ToObject(byte[] objData)
        {
            //return Encoding.UTF8.GetString(objData);
            using (MemoryStream ms = new MemoryStream(objData))
            {
                var bf = new BinaryFormatter();
                return bf.Deserialize(ms);
            }
        }

        public static string Compress(object obj)
        {
            if (obj == null)
                return "";

            var rawData = ToByte(obj);
            using (var ms = new MemoryStream())
            {
                var gs = new GZipStream(ms, CompressionMode.Compress, true);
                gs.Write(rawData, 0, rawData.Length);
                gs.Close();
                var bytes = ms.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }

        public static object Decompress(string base64)
        {
            var zippedData = Convert.FromBase64String(base64);
            using (var ms = new MemoryStream(zippedData))
            using (var gs = new GZipStream(ms, CompressionMode.Decompress))
            using (var os = new MemoryStream())
            {
                var buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = gs.Read(buffer, 0, buffer.Length);
                    if (bytesRead <= 0)
                        break;
                    os.Write(buffer, 0, bytesRead);
                }
                return ToObject(os.ToArray());
            }
        }
    }
}
