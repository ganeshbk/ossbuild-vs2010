using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gst;
using Gst.BasePlugins;

namespace csharp_helloworld
{
    public partial class MainForm : Form
    {
        Gst.GLib.MainLoop m_GLibMainLoop;
        System.Threading.Thread m_GLibThread;

        public MainForm()
        {
            InitializeComponent();

            // Create a main loop for GLib, run it in a separate thread
            m_GLibMainLoop = new Gst.GLib.MainLoop();
            m_GLibThread = new System.Threading.Thread(m_GLibMainLoop.Run);
            m_GLibThread.Start();

            CreatePipeline();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Tell d3dvideosink to render into our window.
            var overlay = new Gst.Interfaces.XOverlayAdapter(m_Sink.Handle);
            overlay.XwindowId = (ulong)videoPanel.Handle;
            
            m_Pipeline.SetState(State.Playing);
            
            m_Pipeline.DebugToDotFile("graph"); // Save pipeline to graph.dot
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_Pipeline.SetState(State.Ready);
        }

    }
}
