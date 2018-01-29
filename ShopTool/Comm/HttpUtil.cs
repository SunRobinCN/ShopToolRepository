using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        public static string InvokePostByHttpUtil(string url, FormUrlEncodedContent parameters)
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
            var encodedContent = new FormUrlEncodedContent(parameters);
            var result = InvokePostByHttpUtil(url, encodedContent);
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

        public static string ConfirmInformationWithWebsite(Product product)
        {
            string result = "";
            var parameters = new Dictionary<string, string>();
            parameters.Add("title", product.Name);
            parameters.Add("explanation", product.Description);
            parameters.Add("input_price", product.Price);
            parameters.Add("new_category_id", product.Category.ID);
            parameters.Add("category_id", product.Category.ID);
            parameters.Add("category_name", product.Category.Name);
            parameters.Add("atr_status", product.Status.ID);
            parameters.Add("send_date_standard", product.LogisticDay.ID);
            //parameters.Add("carry_method", product.LogisticWay.ID);
            parameters.Add("carry_method_flag", "1");
            parameters.Add("carry_fee_type", product.LogisticLiao.ID);
            parameters.Add("area", product.Area.Name);
            parameters.Add("no_price_flag", "0");
            parameters.Add("private_flag", "0");
            parameters.Add("btn1", "1");
            parameters.Add("chakuga_flag", "1");
            parameters.Add("total_mid", "1");
            parameters.Add("rot", "1");
            parameters.Add("carry_condition", "");
            parameters.Add("viewtype", "new");
            StringBuilder builder = new StringBuilder();
            foreach (string productPictureUrl in product.PictureUrls)
            {
                builder.Append(productPictureUrl + ",");
            }
            parameters.Add("picture_url", builder.ToString().Substring(0, builder.Length - 1));
            var encodedContent = new FormUrlEncodedContent(parameters);
            result = InvokePostByHttpUtil(Url.WRITE_ITEM_CONF, encodedContent);
            return result;
        }

        public static string ExcecuteUploadToWebsite(string url, string confID, Product product)
        {
            string result = "";
            var parameters = new Dictionary<string, string>();
            //parameters.Add("title", product.Name);
            //parameters.Add("explanation", product.Description);
            //parameters.Add("input_price", product.Price);
            //parameters.Add("new_category_id", product.Category.ID);
            //parameters.Add("category_id", product.Category.ID);
            //parameters.Add("category_name", product.Category.Name);
            //parameters.Add("atr_status", product.Status.ID);
            //parameters.Add("send_date_standard", product.LogisticDay.ID);
            //parameters.Add("carry_method", product.LogisticWay.ID);
            //parameters.Add("carry_method_flag", "1");
            //parameters.Add("carry_fee_type", product.LogisticLiao.ID);
            //parameters.Add("area", product.Area.Name);
            //parameters.Add("no_price_flag", "0");
            //parameters.Add("private_flag", "0");
            //parameters.Add("btn1", "1");
            //parameters.Add("chakuga_flag", "0");
            //parameters.Add("total_mid", "1");
            //parameters.Add("rot", "1");
            //parameters.Add("carry_condition", "");
            //parameters.Add("conf", confID);
            parameters.Add("category_id", "9104");
            parameters.Add("title", "tttt343");
            parameters.Add("explanation", "ttttttttttttt");
            parameters.Add("carry_fee_type", "1");
            parameters.Add("carry_condition", "%253F%253F%253FO%253F%253F%253F%253F%253F%253F%253F%253F%253F%255D%253F%253F%253F%253F%253F%253F%253F%253F%2540%253F%253F%253F%253F%253F%253F%253F%25E8%2582%25A2%253F%253F%253F%253F%253F%250D%250A%2528%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%2540%253F%253F%253F%253F%255C%2529%250D%250A%250D%250A%253F%253F%253F%253F%253F%253FX%253F%253F%250D%250A%253F%257E%253F%253F%253Fp%253Fb%253FN%253F%253F%253F%253F%253F%253F%2B%253F%253F%250D%250A%253F%253F%253F%253F%253Fp%253Fb%253FN%253F%253F%253F%253F%253F%253F%2B%253F%253F%250D%250A%253F%253F%253F%253F%253F%255E%253F%255B%253Fp%253Fb%253FN%253Fv%253F%253F%253FX%250D%250A%253F%253F%253F%253F%253F%255E%253F%255B%253Fp%253Fb%253FN%253F%253F%253FC%253Fg%250D%250A%253F%253F%253FN%253F%253F%253Fl%253FR%253F%253F%253F%255B%253F%253F%253F%253F%250D%250A%253F%253F%253Fz%253F%253F%253F%253F%253F%253F%253F%253Ft%253F%253F%253F%253F%253F%253F%253F%2540%253F%253F%253F%253F%257D%253F%255B%253FN%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F%253F");
            parameters.Add("input_price", "3333");
            parameters.Add("rot", "1");
            parameters.Add("area", product.Area.Name);
            parameters.Add("no_price_flag", "0");
            parameters.Add("atr_status", "3");
            parameters.Add("send_date_standard", "0");
            parameters.Add("private_flag", "0");
            parameters.Add("total_mid", "1");
            parameters.Add("chakuga_flag", "0");
            parameters.Add("carry_method", "2");

            parameters.Add("brand_id", "");
            parameters.Add("brand_name", "");
            parameters.Add("item_genre_id", "");
            parameters.Add("item_genre_details_id", "");
            parameters.Add("template_id", "");
            parameters.Add("itemnum", "");
            parameters.Add("category_name", "%25E3%2581%259D%25E3%2581%25AE%25E4%25BB%2596");
            parameters.Add("shop_category_id", "");
            parameters.Add("atr_size", "");
            parameters.Add("comment", "");
            parameters.Add("keitou_flag", "");
            parameters.Add("pics", "");
            //parameters.Add("", "");
            //parameters.Add("", "");
            //parameters.Add("", "");
            StringBuilder builder = new StringBuilder();
            foreach (string productPictureUrl in product.PictureUrls)
            {
                builder.Append(productPictureUrl + ",");
            }
            parameters.Add("picture_url", builder.ToString().Substring(0, builder.Length - 1));

            parameters.Add("conf", confID);
            //parameters.Add("", "");

            var encodedContent = new FormUrlEncodedContent(parameters);
            MyHttpClient c = MyHttpClient.GetInstance();
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            c.DefaultRequestHeaders.Referrer = new Uri("https://shoppies.jp/write-item_conf");
            result = InvokePostByHttpUtil(url, encodedContent);
            return result;
        }
     
        public static string UploadBatchesToWebsite(List<OneUserBatch> batches)
        {
            string result = "";
            foreach (OneUserBatch oneUserBatch in batches)
            {
                LoginToShopWebsite(oneUserBatch.Username, oneUserBatch.Password);
                foreach (Product product in oneUserBatch.Products)
                {
                    List<string> uploadPicturesResult = UploadPictureToWebsite(product.Pictures);
                    product.PictureUrls = uploadPicturesResult;
                    string r = ConfirmInformationWithWebsite(product);
                    string confirmSessionId = GetConfirmSessionID(r);
                    string uploadURL = string.Format("https://shoppies.jp/index_pc.php?ses_id={0}&jb=write-item_end",
                        confirmSessionId);
                    string confimID = GetConfirmID(r);
                    ExcecuteUploadToWebsite(uploadURL, confimID, product);
                }
            }

            return result;
        }

        private static string GetConfirmSessionID(string content)
        {
            int start = content.IndexOf("/index_pc.php?", StringComparison.Ordinal) + 21;
            string resultSubstring = content.Substring(start, 10);
            return resultSubstring;
        }

        private static string GetConfirmID(string content)
        {
            int start = content.IndexOf(@"conf", StringComparison.Ordinal) + 15;
            string resultSubstring = content.Substring(start, 40);
            return resultSubstring;
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
                var encodedContent = new FormUrlEncodedContent(parameters);
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

    }
}
