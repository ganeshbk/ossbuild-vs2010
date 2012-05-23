// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Interfaces {

	using System;
	using System.Runtime.InteropServices;
	using System.Reflection;

#region Autogenerated code
	public partial class ColorBalanceAdapter : Gst.GLib.GInterfaceAdapter, Gst.Interfaces.ColorBalance {

		[StructLayout (LayoutKind.Sequential)]
		struct GstColorBalanceClass {
			public Gst.Interfaces.ColorBalanceType BalanceType;
			public ListChannelsNativeDelegate ListChannels;
			public SetValueNativeDelegate SetValue;
			public GetValueNativeDelegate GetValue;
			IntPtr ValueChanged;
			[MarshalAs (UnmanagedType.ByValArray, SizeConst=4)]
			public IntPtr[] GstReserved;
		}

		static GstColorBalanceClass iface;

		static ColorBalanceAdapter ()
		{
			Gst.GLib.GType.Register (_gtype, typeof(ColorBalanceAdapter));
			iface.ListChannels = new ListChannelsNativeDelegate (ListChannels_cb);
			iface.SetValue = new SetValueNativeDelegate (SetValue_cb);
			iface.GetValue = new GetValueNativeDelegate (GetValue_cb);
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate IntPtr ListChannelsNativeDelegate (IntPtr inst);

		static IntPtr ListChannels_cb (IntPtr inst)
		{
			try {
				ColorBalanceImplementor __obj = Gst.GLib.Object.GetObject (inst, false) as ColorBalanceImplementor;
				Gst.Interfaces.ColorBalanceChannel[] __result = __obj.ListChannels ();
				return new Gst.GLib.List(__result, typeof (Gst.Interfaces.ColorBalanceChannel), false, false) == null ? IntPtr.Zero : new Gst.GLib.List(__result, typeof (Gst.Interfaces.ColorBalanceChannel), false, false).Handle;
			} catch (Exception e) {
				Gst.GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void SetValueNativeDelegate (IntPtr inst, IntPtr channel, int value);

		static void SetValue_cb (IntPtr inst, IntPtr channel, int value)
		{
			try {
				ColorBalanceImplementor __obj = Gst.GLib.Object.GetObject (inst, false) as ColorBalanceImplementor;
				__obj.SetValue (Gst.GLib.Object.GetObject(channel) as Gst.Interfaces.ColorBalanceChannel, value);
			} catch (Exception e) {
				Gst.GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate int GetValueNativeDelegate (IntPtr inst, IntPtr channel);

		static int GetValue_cb (IntPtr inst, IntPtr channel)
		{
			try {
				ColorBalanceImplementor __obj = Gst.GLib.Object.GetObject (inst, false) as ColorBalanceImplementor;
				int __result = __obj.GetValue (Gst.GLib.Object.GetObject(channel) as Gst.Interfaces.ColorBalanceChannel);
				return __result;
			} catch (Exception e) {
				Gst.GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		static int class_offset = 2 * IntPtr.Size;

		static void Initialize (IntPtr ptr, IntPtr data)
		{
			IntPtr ifaceptr = new IntPtr (ptr.ToInt64 () + class_offset);
			GstColorBalanceClass native_iface = (GstColorBalanceClass) Marshal.PtrToStructure (ifaceptr, typeof (GstColorBalanceClass));
			native_iface.ListChannels = iface.ListChannels;
			native_iface.SetValue = iface.SetValue;
			native_iface.GetValue = iface.GetValue;

			GCHandle gch = (GCHandle) data;
			ColorBalanceAdapter adapter = gch.Target as ColorBalanceAdapter;

			ColorBalanceImplementor implementor = adapter.Implementor;
			if (implementor != null) {
			  PropertyInfo pi = implementor.GetType().GetProperty ("BalanceType", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
			  if (pi != null && pi.PropertyType == typeof (Gst.Interfaces.ColorBalanceType))
			    native_iface.BalanceType = (Gst.Interfaces.ColorBalanceType) pi.GetValue (null, null);
			}

			Marshal.StructureToPtr (native_iface, ifaceptr, false);
			gch.Free ();
		}

		Gst.GLib.Object implementor;

		public ColorBalanceAdapter ()
		{
			InitHandler = new Gst.GLib.GInterfaceInitHandler (Initialize);
		}

		public ColorBalanceAdapter (ColorBalanceImplementor implementor)
		{
			if (implementor == null)
				throw new ArgumentNullException ("implementor");
			else if (!(implementor is Gst.GLib.Object))
				throw new ArgumentException ("implementor must be a subclass of Gst.GLib.Object");
			this.implementor = implementor as Gst.GLib.Object;
		}

		public ColorBalanceAdapter (IntPtr handle)
		{
			if (!_gtype.IsInstance (handle))
				throw new ArgumentException ("The gobject doesn't implement the GInterface of this adapter", "handle");
			implementor = Gst.GLib.Object.GetObject (handle);
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_color_balance_get_type();

		private static Gst.GLib.GType _gtype = new Gst.GLib.GType (gst_color_balance_get_type ());

		public override Gst.GLib.GType GType {
			get {
				return _gtype;
			}
		}

		public override IntPtr Handle {
			get {
				return implementor.Handle;
			}
		}

		public IntPtr OwnedHandle {
			get {
				return implementor.OwnedHandle;
			}
		}

		public static ColorBalance GetObject (IntPtr handle, bool owned)
		{
			Gst.GLib.Object obj = Gst.GLib.Object.GetObject (handle, owned);
			return GetObject (obj);
		}

		public static ColorBalance GetObject (Gst.GLib.Object obj)
		{
			if (obj == null)
				return null;
			else if (obj is ColorBalanceImplementor)
				return new ColorBalanceAdapter (obj as ColorBalanceImplementor);
			else if (obj as ColorBalance == null)
				return new ColorBalanceAdapter (obj.Handle);
			else
				return obj as ColorBalance;
		}

		public ColorBalanceImplementor Implementor {
			get {
				return implementor as ColorBalanceImplementor;
			}
		}

		[Gst.GLib.Signal("value-changed")]
		public event Gst.Interfaces.ValueChangedHandler ValueChanged {
			add {
				Gst.GLib.Signal sig = Gst.GLib.Signal.Lookup (Gst.GLib.Object.GetObject (Handle), "value-changed", typeof (Gst.Interfaces.ValueChangedArgs));
				sig.AddDelegate (value);
			}
			remove {
				Gst.GLib.Signal sig = Gst.GLib.Signal.Lookup (Gst.GLib.Object.GetObject (Handle), "value-changed", typeof (Gst.Interfaces.ValueChangedArgs));
				sig.RemoveDelegate (value);
			}
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_color_balance_set_value(IntPtr raw, IntPtr channel, int value);

		public void SetValue(Gst.Interfaces.ColorBalanceChannel channel, int value) {
			gst_color_balance_set_value(Handle, channel == null ? IntPtr.Zero : channel.Handle, value);
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_color_balance_list_channels(IntPtr raw);

		public Gst.Interfaces.ColorBalanceChannel[] ListChannels() {
			IntPtr raw_ret = gst_color_balance_list_channels(Handle);
			Gst.Interfaces.ColorBalanceChannel[] ret = (Gst.Interfaces.ColorBalanceChannel[]) Gst.GLib.Marshaller.ListPtrToArray (raw_ret, typeof(Gst.GLib.List), false, false, typeof(Gst.Interfaces.ColorBalanceChannel));
			return ret;
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_color_balance_get_value(IntPtr raw, IntPtr channel);

		public int GetValue(Gst.Interfaces.ColorBalanceChannel channel) {
			int raw_ret = gst_color_balance_get_value(Handle, channel == null ? IntPtr.Zero : channel.Handle);
			int ret = raw_ret;
			return ret;
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_color_balance_get_balance_type(IntPtr raw);

		public Gst.Interfaces.ColorBalanceType BalanceType { 
			get {
				int raw_ret = gst_color_balance_get_balance_type(Handle);
				Gst.Interfaces.ColorBalanceType ret = (Gst.Interfaces.ColorBalanceType) raw_ret;
				return ret;
			}
		}

		[DllImport("libgstinterfaces-0.10.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_color_balance_value_changed(IntPtr raw, IntPtr channel, int value);

		public void EmitValueChanged(Gst.Interfaces.ColorBalanceChannel channel, int value) {
			gst_color_balance_value_changed(Handle, channel == null ? IntPtr.Zero : channel.Handle, value);
		}

#endregion
	}
}