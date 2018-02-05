using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Log;
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
            ReWriteToFile(path, json);
        }

        public static List<User> GetUsers()
        {
            List<User> list = null;
            try
            {
                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\user.data";
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
            }
            catch (Exception e)
            {
                FileLog.Error("GetUsers", e, LogType.Error);
            }
            return list ?? new List<User>();
        }

        public static void ArchiveProduct(Product p)
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\products.data";
            if (File.Exists(path) == false)
            {
                File.Create(path);
            }
            p.Pictures = null;
            var json = JsonConvert.SerializeObject(p);
            AppendToFile(path, json + ","); 
        }

        public static void ReWriteToFile(string path, string message)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
                writer.Write(message);
                writer.Close();
            }
        }

        public static void AppendToFile(string path, string message)
        {
            bool signal = true;
            do
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Append))
                    {
                        StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
                        writer.Write(message);
                        writer.Flush();
                        writer.Close();
                        signal = false;
                    }
                }
                catch (System.IO.IOException e)
                {
                    FileLog.Error("AppendToFile", e, LogType.Error);
                }
            } while (signal);
        }

        public static List<Product> GetProducts()
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\products.data";
            List<Product> list = null;
            try
            {
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
                    }
                    finally
                    {
                        fileStream?.Close();
                    }
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
                {
                    string content = reader.ReadToEnd();
                    if (content.EndsWith(","))
                    {
                        content = content.Remove(content.Length - 1);
                    }
                    content = "[" + content + "]";
                    list = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception e)
            {
                FileLog.Error("GetProducts", e, LogType.Error);
            }
            return list ?? new List<Product>();
        }
    }
}
