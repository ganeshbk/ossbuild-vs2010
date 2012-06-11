using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Gst;

namespace MyPlugin
{
    public class MyPlugin: Gst.Video.VideoFilter
    {
        /// <summary>
        /// This method is called by GStreamer (through PluginWrapper)
        /// when an application looks up available plugins.
        /// </summary>
        protected static bool Register(Plugin plugin)
        {
            Gst.GLib.GType gtype = (Gst.GLib.GType)typeof(MyPlugin);
            SetDetails(gtype, "My C# example plugin", "Effect/Video",
                "This is an example of using C# to write GStreamer plugins.",
                "Petteri Aimonen");
            return ElementFactory.Register(plugin, "myplugin", (uint)Rank.None, gtype);
        }

        /// <summary>
        /// Static constructor is a good place to initialize the pad templates.
        /// This way they are available even to stand-alone applications that don't call Register().
        /// </summary>
        static MyPlugin()
        {
            Gst.GLib.GType gtype = (Gst.GLib.GType)typeof(MyPlugin);

            Caps caps = new Caps("video/x-raw-rgb", "bpp", 32, "red_mask", 0xFF00);
            AddPadTemplate(gtype, new PadTemplate("sink", PadDirection.Sink, PadPresence.Always, caps));
            AddPadTemplate(gtype, new PadTemplate("src", PadDirection.Src, PadPresence.Always, caps));
        }

        /// <summary>
        /// This constructor is used by GStreamer when creating the instance.
        /// </summary>
        public MyPlugin(IntPtr raw): base(raw)
        {
        }

        /// <summary>
        /// You can use this constructor from C# programs if you want.
        /// </summary>
        public MyPlugin(): base()
        {
        }

        /// <summary>
        /// This is the actual implementation of our element.
        /// </summary>
        protected override FlowReturn OnTransformIp(Gst.Buffer buf)
        {
            int width = (int)buf.Caps[0]["width"];
            int height = (int)buf.Caps[0]["height"];
            Bitmap b = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppRgb, buf.Data);
            Graphics g = Graphics.FromImage(b);
            g.DrawString("Hello from C#!", new Font(FontFamily.GenericSansSerif, 20), Brushes.Red, new PointF(10, 10));
            g.Dispose();
            b.Dispose();

            return base.OnTransformIp(buf);
        }
    }
}
