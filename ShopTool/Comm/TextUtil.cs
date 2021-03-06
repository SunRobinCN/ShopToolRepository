﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Log;
using Newtonsoft.Json;
using ShopTool.Model;

namespace ShopTool.Comm
{
    public static class TextUtil
    {
        public static void ArchiveUsers(List<User> users)
        {
            string folderpath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config";
            string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase +  @"\Config\user.data";
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            if (!File.Exists(filepath))
            {
                Stream fileStream = null;
                try
                {
                    fileStream = File.Create(filepath);
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
            var json = JsonConvert.SerializeObject(users);
            ReWriteToFile(filepath, json);
        }

        public static List<User> GetUsers()
        {
            List<User> list = null;
            try
            {
                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\user.data";
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

        public static void RefreshProducts(List<Product> list)
        {
            string folderpath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config";
            string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\products.data";
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            foreach (Product product in list)
            {
                ArchiveProduct(product);
            }
        }

        public static void ArchiveProduct(Product p)
        {
            string folderpath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config";
            string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\products.data";
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            if (!File.Exists(filepath))
            {
                Stream fileStream = null;
                try
                {
                    fileStream = File.Create(filepath);
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
            ArchiveProductImage(p);
            p.Pictures = null;
            var json = JsonConvert.SerializeObject(p);
            AppendToFile(filepath, json + ","); 
        }

        private static void ArchiveProductImage(Product product)
        {
            if (product.ImagePaths.Count > 0)
            {
                return;
            }
            List<Image> images = product.Pictures;
            int count = 0;
            foreach (Image image in images?? new List<Image>())
            {
                string format = "";
                GetImageFormat(image, out format);
                string folderPath = System.Environment.CurrentDirectory + "/Images/" + DateTime.Now.ToString("yyyy_MM_dd") + "/";
                if (Directory.Exists(folderPath) == false)
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = product.Id + "_" + count++ + format;
                string fullPath = folderPath + fileName;
                //image.Save(fullPath);
                Bitmap bitmap = new Bitmap(image);
                bitmap.Save(fullPath);
                if (product.ImagePaths.Count < product.Pictures.Count)
                {
                    product.ImagePaths.Add(fullPath);
                }
            }
        }

        private static System.Drawing.Imaging.ImageFormat GetImageFormat(Image _img, out string format)
        {
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                format = ".jpg";
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
            {
                format = ".gif";
                return System.Drawing.Imaging.ImageFormat.Gif;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                format = ".png";
                return System.Drawing.Imaging.ImageFormat.Png;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            {
                format = ".bmp";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            format = string.Empty;
            return null;
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
                FileLog.Info("GetProducts not find related file!", LogType.Info);
            }
            return list ?? new List<Product>();
        }
    }
}
