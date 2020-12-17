using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Baoxiaohe
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private const String UA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.88 Safari/537.36";

        private const int defaultDevPort = 99678;  // 默认端口

        public App()
        {
            Application.Current.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var settings = new CefSettings
            {
                RemoteDebuggingPort = defaultDevPort,
                CachePath = System.IO.Path.GetFullPath("cache"),
            };
            settings.UserAgent = UA;
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("--disable-pinch", "1");
            settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            Cef.Initialize(settings);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            Console.WriteLine("发生异常：" + exception.Message);
        }


        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("发生异常：" + e.Exception.Message);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Cef.Shutdown();
            base.OnExit(e);
        }
    }
}
