using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace csharp_helloworld
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // These environment variables are necessary to locate GStreamer libraries, and to stop it from loading
            // wrong libraries installed elsewhere on the system.
            string apppath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
