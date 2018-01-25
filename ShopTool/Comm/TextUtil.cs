using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ShopTool.Model;

namespace ShopTool.Comm
{
    public static class TextUtil
    {
        public static void ArchiveUsers(List<User> users)
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase +  @"\Config\user.data";
            var json = JsonConvert.SerializeObject(users);
            WriteToFile(path, json);
        }

        public static List<User> GetUsers()
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase +  @"\Config\user.data";
            List<User> list;
            if (!File.Exists(path))
            {
                Stream fileStream = null;
                try
                {
                    fileStream = File.Create(path);
                }
                catch (Exception)
                {
                    if (fileStream != null) fileStream.Close();
                    throw;
                }
                finally
                {
                    fileStream?.Close();
                }
            }
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string content = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<User>>(content);
            }
            return list ?? new List<User>();
        }

        public static void ArchiveProducts(List<Product> list)
        {
            string path = "";
            var json = JsonConvert.SerializeObject(list);
            WriteToFile(path, json);
        }

        public static void WriteToFile(string path, string message)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
                writer.Write(message);
                writer.Close();
            }
        }

        public static List<Product> GetProducts()
        {
            string path = "";
            List<Product> list;
            if (!File.Exists(path))
            {
                Stream fileStream = null;
                try
                {
                    fileStream = File.Create(path);
                }
                catch (Exception)
                {
                    if (fileStream != null) fileStream.Close();
                    throw;
                }
                finally
                {
                    fileStream?.Close();
                }
            }
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string content = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return list ?? new List<Product>();
        }
    }
}
