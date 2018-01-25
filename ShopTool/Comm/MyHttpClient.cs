using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ShopTool
{
    public class MyHttpClient : HttpClient
    {
        private static MyHttpClient _instance;

        private MyHttpClient()
        {
        }

        public static MyHttpClient GetInstance()
        {
            if (null == _instance)
            {
                _instance = new MyHttpClient();
            }
            return _instance;
        }


        public new static void Dispose()
        {
            ((HttpMessageInvoker) _instance)?.Dispose();
        }
    }
}
