﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using ShopTool.CefFilters;

namespace ShopTool
{
    public class MyRequestHandler : IRequestHandler
    {
        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            return false;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
            WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl,
            ISslInfo sslInfo, IRequestCallback callback)
        {
            return true;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IRequestCallback callback)
        {
            return CefReturnValue.Continue;
        }

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port,
            string realm, string scheme, IAuthCallback callback)
        {
            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port,
            X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize,
            IRequestCallback callback)
        {
            return false;
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IResponse response, ref string newUrl)
        {
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return false;
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IResponse response)
        {
            return false;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IResponse response)
        {
            try
            {
                if (request.Url == "https://shoppies.jp/write-item_sp" 
                    || request.Url == "https://shoppies.jp/?jb=write-item_sp"
                    || request.Url == "https://shoppies.jp/write-item_conf"
                    || request.Url.StartsWith("https://shoppies.jp/index_pc.php?ses_id"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>
                    {
                        {
                            "https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js",
                            "https://libs.baidu.com/jquery/1.10.2/jquery.min.js"
                        }
                    };
                    return new FindReplaceResponseFilter(dictionary);
                }
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            CookieVisitor _cookieVisitor = new CookieVisitor();
            Cef.GetGlobalCookieManager().VisitAllCookies(_cookieVisitor);
        }
    }

    public class JsDialogHandler : IJsDialogHandler
    {
        //当一个JS alert窗口等在显示的时候，会先调用这个方法，如果返回true，则停止显示窗口，如果返回false，则继续显示窗口
        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType,
            string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            Debug.WriteLine(messageText);

            //callback.Continue(true);
            //return true;

            return false;
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload,
            IJsDialogCallback callback)
        {
            return true;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}
