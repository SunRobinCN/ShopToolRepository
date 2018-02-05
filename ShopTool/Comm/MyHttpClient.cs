using System.Net.Http;

namespace ShopTool.Comm
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
            _instance = null;
        }
    }
}
