using System;
using System.Collections;
using System.Runtime.InteropServices;
using Gst.GLib;
using Gst;
using Gst.Interfaces;

namespace Gst.CorePlugins {
#region Autogenerated code
	[GTypeName ("GstIdentity")]
	public sealed class Identity : Gst.Base.BaseTransform {
		public Identity (IntPtr raw) : base (raw) { }

		[DllImport("libgstreamer-0.10.dll") ]
		static extern IntPtr gst_element_factory_make (IntPtr element, IntPtr name);

		public Identity (string name) : base (IntPtr.Zero) {
			IntPtr native_name = Gst.GLib.Marshaller.StringToPtrGStrdup (name);
			IntPtr native_element = Gst.GLib.Marshaller.StringToPtrGStrdup ("identity");
			Raw = gst_element_factory_make (native_element, native_name);
			Gst.GLib.Marshaller.Free (native_name);
			Gst.GLib.Marshaller.Free (native_element);
			if (Raw == IntPtr.Zero)
				throw new Exception ("Failed to instantiate element \"identity\"");
		}

		public Identity () : this ((string) null) { }

		public static Identity Make (string name) {
			return Gst.ElementFactory.Make ("identity", name) as Identity;
		}

		public static Identity Make () { return Make (null); } 

		[Gst.GLib.Property ("name")]
		public string Name {
			get {
				Gst.GLib.Value val = GetProperty ("name");
				string ret = (string) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "name");
				val.Val = value;
				SetProperty ("name", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("qos")]
		public bool Qos {
			get {
				Gst.GLib.Value val = GetProperty ("qos");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "qos");
				val.Val = value;
				SetProperty ("qos", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("sleep-time")]
		public uint SleepTime {
			get {
				Gst.GLib.Value val = GetProperty ("sleep-time");
				uint ret = (uint) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "sleep-time");
				val.Val = value;
				SetProperty ("sleep-time", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("error-after")]
		public int ErrorAfter {
			get {
				Gst.GLib.Value val = GetProperty ("error-after");
				int ret = (int) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "error-after");
				val.Val = value;
				SetProperty ("error-after", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("drop-probability")]
		public float DropProbability {
			get {
				Gst.GLib.Value val = GetProperty ("drop-probability");
				float ret = (float) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "drop-probability");
				val.Val = value;
				SetProperty ("drop-probability", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("datarate")]
		public int Datarate {
			get {
				Gst.GLib.Value val = GetProperty ("datarate");
				int ret = (int) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "datarate");
				val.Val = value;
				SetProperty ("datarate", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("silent")]
		public bool Silent {
			get {
				Gst.GLib.Value val = GetProperty ("silent");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "silent");
				val.Val = value;
				SetProperty ("silent", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("single-segment")]
		public bool SingleSegment {
			get {
				Gst.GLib.Value val = GetProperty ("single-segment");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "single-segment");
				val.Val = value;
				SetProperty ("single-segment", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("last-message")]
		public string LastMessage {
			get {
				Gst.GLib.Value val = GetProperty ("last-message");
				string ret = (string) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "last-message");
				val.Val = value;
				SetProperty ("last-message", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("dump")]
		public bool Dump {
			get {
				Gst.GLib.Value val = GetProperty ("dump");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "dump");
				val.Val = value;
				SetProperty ("dump", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("sync")]
		public bool Sync {
			get {
				Gst.GLib.Value val = GetProperty ("sync");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "sync");
				val.Val = value;
				SetProperty ("sync", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("check-perfect")]
		public bool CheckPerfect {
			get {
				Gst.GLib.Value val = GetProperty ("check-perfect");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "check-perfect");
				val.Val = value;
				SetProperty ("check-perfect", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("check-imperfect-timestamp")]
		public bool CheckImperfectTimestamp {
			get {
				Gst.GLib.Value val = GetProperty ("check-imperfect-timestamp");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "check-imperfect-timestamp");
				val.Val = value;
				SetProperty ("check-imperfect-timestamp", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("check-imperfect-offset")]
		public bool CheckImperfectOffset {
			get {
				Gst.GLib.Value val = GetProperty ("check-imperfect-offset");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "check-imperfect-offset");
				val.Val = value;
				SetProperty ("check-imperfect-offset", val);
				val.Dispose ();
			}
		}

		[Gst.GLib.Property ("signal-handoffs")]
		public bool SignalHandoffs {
			get {
				Gst.GLib.Value val = GetProperty ("signal-handoffs");
				bool ret = (bool) val.Val;
				val.Dispose ();
				return ret;
			}
			set {
				Gst.GLib.Value val = new Gst.GLib.Value (this, "signal-handoffs");
				val.Val = value;
				SetProperty ("signal-handoffs", val);
				val.Dispose ();
			}
		}


		public delegate void HandoffHandler (object o, HandoffArgs args);

		public class HandoffArgs : Gst.GLib.SignalArgs {
			public Gst.Buffer Buffer {
				get {
					return (Gst.Buffer) Args[0];
				}
			}

		}

		public event HandoffHandler Handoff {
			add {
				DynamicSignal.Connect (this, "handoff", value);
			}

			remove {
				DynamicSignal.Disconnect (this, "handoff", value);
			}
		}
#endregion
	}

}
