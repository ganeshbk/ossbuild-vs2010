using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace csharp_net4_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            : base()
        {
            // These environment variables are necessary to locate GStreamer libraries, and to stop it from loading
            // wrong libraries installed elsewhere on the system.
            string apppath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\..\..";
            System.Environment.SetEnvironmentVariable("GST_PLUGIN_PATH", "");
            System.Environment.SetEnvironmentVariable("GST_PLUGIN_SYSTEM_PATH", apppath + @"\gstreamer\bin\plugins");
            System.Environment.SetEnvironmentVariable("PATH", @"C:\Windows;"
                                                        + apppath + @"\gstreamer\lib;"
                                                        + apppath + @"\gstreamer\bin");

            // These are for saving debug information.
            System.Environment.SetEnvironmentVariable("GST_DEBUG", "*:3");
            System.Environment.SetEnvironmentVariable("GST_DEBUG_FILE", "GstreamerLog.txt");
            System.Environment.SetEnvironmentVariable("GST_DEBUG_DUMP_DOT_DIR", apppath);

            Gst.Application.Init();
        }
    }
}
