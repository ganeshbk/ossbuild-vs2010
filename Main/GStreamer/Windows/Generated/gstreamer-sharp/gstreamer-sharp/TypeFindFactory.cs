// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class TypeFindFactory : Gst.PluginFeature {

		public TypeFindFactory(IntPtr raw) : base(raw) {}

		protected TypeFindFactory() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new Gst.GLib.Value [0]);
		}

		[DllImport("libgstreamer-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_type_find_factory_get_extensions(IntPtr raw);

		public string[] Extensions {
			get  {
				IntPtr raw_ret = gst_type_find_factory_get_extensions(Handle);
				string[] ret = Gst.Marshaller.NullTermPtrToStringArray (raw_ret, false);
				return ret;
			}
		}

		[DllImport("libgstreamer-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_type_find_factory_get_caps(IntPtr raw);

		public Gst.Caps Caps {
			get  {
				IntPtr raw_ret = gst_type_find_factory_get_caps(Handle);
				Gst.Caps ret = raw_ret == IntPtr.Zero ? null : (Gst.Caps) Gst.GLib.Opaque.GetOpaque (raw_ret, typeof (Gst.Caps), false);
				return ret;
			}
		}

		[StructLayout (LayoutKind.Sequential)]
		struct GstTypeFindFactoryClass {
			[MarshalAs (UnmanagedType.ByValArray, SizeConst=4)]
			public IntPtr[] GstReserved;
		}

		static uint class_offset = ((Gst.GLib.GType) typeof (Gst.PluginFeature)).GetClassSize ();
		static Hashtable class_structs;

		static GstTypeFindFactoryClass GetClassStruct (Gst.GLib.GType gtype, bool use_cache)
		{
			if (class_structs == null)
				class_structs = new Hashtable ();

			if (use_cache && class_structs.Contains (gtype))
				return (GstTypeFindFactoryClass) class_structs [gtype];
			else {
				IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
				GstTypeFindFactoryClass class_struct = (GstTypeFindFactoryClass) Marshal.PtrToStructure (class_ptr, typeof (GstTypeFindFactoryClass));
				if (use_cache)
					class_structs.Add (gtype, class_struct);
				return class_struct;
			}
		}

		static void OverrideClassStruct (Gst.GLib.GType gtype, GstTypeFindFactoryClass class_struct)
		{
			IntPtr class_ptr = new IntPtr (gtype.GetClassPtr ().ToInt64 () + class_offset);
			Marshal.StructureToPtr (class_struct, class_ptr, false);
		}

		[DllImport("libgstreamer-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_type_find_factory_call_function(IntPtr raw, IntPtr find);

		public void CallFunction(Gst.TypeFind find) {
			gst_type_find_factory_call_function(Handle, find == null ? IntPtr.Zero : find.Handle);
		}

		[DllImport("libgstreamer-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_type_find_factory_get_list();

		public static Gst.TypeFindFactory[] List { 
			get {
				IntPtr raw_ret = gst_type_find_factory_get_list();
				Gst.TypeFindFactory[] ret = (Gst.TypeFindFactory[]) Gst.GLib.Marshaller.ListPtrToArray (raw_ret, typeof(Gst.GLib.List), true, true, typeof(Gst.TypeFindFactory));
				return ret;
			}
		}

		[DllImport("libgstreamer-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_type_find_factory_get_type();

		public static new Gst.GLib.GType GType { 
			get {
				IntPtr raw_ret = gst_type_find_factory_get_type();
				Gst.GLib.GType ret = new Gst.GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
#region Customized extensions
#line 1 "TypeFindFactory.custom"
[DllImport ("libgstreamer-0.10.dll") ]
static extern bool gst_type_find_register (IntPtr plugin, IntPtr name, uint rank, GstSharp.TypeFindFunctionNative func, IntPtr[] extensions, IntPtr possible_caps, IntPtr data, IntPtr data_notify);

public static bool Register (Gst.Plugin plugin, string name, uint rank, Gst.TypeFindFunction func, string[] extensions, Gst.Caps possible_caps) {
  IntPtr native_name = Gst.GLib.Marshaller.StringToPtrGStrdup (name);
  IntPtr[] native_extensions = Gst.GLib.Marshaller.StringArrayToNullTermPointer (extensions);
  GstSharp.TypeFindFunctionWrapper func_wrapper = new GstSharp.TypeFindFunctionWrapper (func);
  bool raw_ret = gst_type_find_register (plugin == null ? IntPtr.Zero : plugin.Handle, native_name, rank, func_wrapper.NativeDelegate, native_extensions, possible_caps == null ? IntPtr.Zero : possible_caps.Handle, IntPtr.Zero, IntPtr.Zero);
  bool ret = raw_ret;
  Gst.GLib.Marshaller.Free (native_name);
  Gst.GLib.Marshaller.Free (native_extensions);
  return ret;
}


#endregion
	}
}
