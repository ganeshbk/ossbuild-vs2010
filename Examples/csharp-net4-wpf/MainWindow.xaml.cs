using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gst;

namespace csharp_net4_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gst.GLib.MainLoop m_GLibMainLoop;
        System.Threading.Thread m_GLibThread;

        public MainWindow()
        {
            InitializeComponent();

            // Create a main loop for GLib, run it in a separate thread
            m_GLibMainLoop = new Gst.GLib.MainLoop();
            m_GLibThread = new System.Threading.Thread(m_GLibMainLoop.Run);
            m_GLibThread.Name = "GLibMainLoop";
            m_GLibThread.Start();

            System.Threading.Thread.CurrentThread.Name = "WinForms";

            CreatePipeline();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_GLibMainLoop.Quit();
        }


        Pipeline m_Pipeline;
        Element m_Source, m_Sink;

        private void CreatePipeline()
        {
            m_Pipeline = new Pipeline();

            m_Source = Gst.ElementFactory.Make("videotestsrc");
            m_Source["pattern"] = 18; // Example of setting element properties

            m_Sink = Gst.ElementFactory.Make("d3dvideosink");

            m_Pipeline.Add(m_Source, m_Sink);
            m_Source.Link(m_Sink);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // Tell d3dvideosink to render into our window.
            var overlay = new Gst.Interfaces.XOverlayAdapter(m_Sink.Handle);
            overlay.XwindowId = (ulong)videoPanel.Handle;

            m_Pipeline.SetState(State.Playing);
            
            m_Pipeline.DebugToDotFile("graph"); // Save pipeline to graph.dot
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            m_Pipeline.SetState(State.Ready);
        }

    }
}
