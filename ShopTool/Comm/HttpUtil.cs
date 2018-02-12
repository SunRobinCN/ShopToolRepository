using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopTool.Model;

namespace ShopTool.Comm
{
    public static class HttpUtil
    {
        public static string InvokeGetByHttpUtil(string url)
        {
            MyHttpClient myHttpClient = MyHttpClient.GetInstance();

            Task<HttpResponseMessage> task = myHttpClient.GetAsync(url);
            HttpResponseMessage response = task.Result;
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return result;
        }

        public static string InvokePostByHttpUtil(string url, MyFormUrlEncodedContent parameters)
        {
            MyHttpClient myHttpClient = MyHttpClient.GetInstance();
            Task<HttpResponseMessage> task = myHttpClient.PostAsync(url, parameters);
            HttpResponseMessage response = task.Result;
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return result;
        }

        private static void LoginByHttpUtil(string url, string username, string password, string sessionID)
        {
            var parameters = new Dictionary<string, string> { { "ses_id", sessionID }, { "loginid", username }, { "password", password }, { "loginforid", "1" }, { "loginbtn", "%83%8D%83O%83C%83%93" } };
            var encodedContent = new MyFormUrlEncodedContent(parameters);
            var result = InvokePostByHttpUtil(url, encodedContent);
            if (result.Contains("#changeLogin"))
            {
                throw new Exception("用户名与密码出现问题！");
            }
        }

        private static string GetSessionIDFromHeaders(string content)
        {
            int start = content.IndexOf("ses_id", StringComparison.Ordinal) + 17;
            string resultSubstring = content.Substring(start, 32);
            return resultSubstring;
        }

        public static void LoginToShopWebsite(string username, string password)
        {
            InvokeGetByHttpUtil(Url.HOME_PAGE);
            string loginPageContent = InvokeGetByHttpUtil(Url.WRITE_ITEM_SP);
            string sessionID = GetSessionIDFromHeaders(loginPageContent);
            LoginByHttpUtil(Url.JB_WRITE_ITEM_SP, username, password, sessionID);
        }

        public static List<string> UploadPictureToWebsite(List<Image> pictureImages)
        {
            List<string> list = new List<string>();
            foreach (Image pictureImage in pictureImages)
            {
                var parameters = new Dictionary<string, string>();
                string base64PictrueStr = GetBase64FromImage(pictureImage);
                parameters.Add("dataUrl", base64PictrueStr);
                parameters.Add("block", "0");

                var encodedContent = new MyFormUrlEncodedContent(parameters);

                string result = InvokePostByHttpUtil(Url.UPLOAD_IMAGE, encodedContent);
                string imageUrl = GetImageUrlFromResponse(result);
                list.Add(imageUrl);
            }
            return list;
        }

        private static string GetImageUrlFromResponse(string response)
        {
            int start = response.IndexOf(@"name", StringComparison.Ordinal) + 7;
            string resultSubstring = response.Substring(start, 19);
            return resultSubstring;
        }

        public static string GetBase64FromImage(Image imagefile)
        {
            string strbaser64 = "";
            Bitmap bmp = new Bitmap(imagefile);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            strbaser64 = Convert.ToBase64String(arr);
            return "data:image/jpeg;base64," + strbaser64;
        }

        public static void Dispose()
        {
            MyHttpClient.Dispose();
        }

    }


    public class MyFormUrlEncodedContent : ByteArrayContent
    {
        public MyFormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
            : base(MyFormUrlEncodedContent.GetContentByteArray(nameValueCollection))
        {
            base.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        }
        private static byte[] GetContentByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException("nameValueCollection");
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> current in nameValueCollection)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append('&');
                }

                stringBuilder.Append(MyFormUrlEncodedContent.Encode(current.Key));
                stringBuilder.Append('=');
                stringBuilder.Append(MyFormUrlEncodedContent.Encode(current.Value));
            }
            return Encoding.Default.GetBytes(stringBuilder.ToString());
        }
        private static string Encode(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            return System.Net.WebUtility.UrlEncode(data).Replace("%20", "+");
        }
    }
}
