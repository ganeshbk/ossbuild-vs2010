/* This is a managed C++ wrapper to make GStreamer plugins written in C#
 * accessible from C programs, such as gst-launch and gst-inspect.
 *
 * The wrapper binary automatically determines the C# .dll name from its
 * own name. Therefore there is no need to recompile it for different
 * plugin modules. You might want to do that anyway in order to customize
 * the text in GstPluginDesc, especially if you plan to distribute the
 * results.
 *
 * (C) 2012 Petteri Aimonen <jpa@gst.mail.kapsi.fi>
 * This file (PluginWrapper.cpp) is placed in the public domain.
 */

#include <gst/gst.h>

using namespace System;
using namespace System::Reflection;

#ifndef PACKAGE
#define PACKAGE "csharppluginwrapper"
#endif

static gboolean wrapper_init (GstPlugin* plugin)
{
  Assembly ^myAssembly = Assembly::GetExecutingAssembly();
  String ^myLoc = myAssembly->Location;
  String ^pluginLoc = myLoc->Replace(".wrap.dll", ".dll");
  Assembly ^pluginAsm = Assembly::LoadFrom(pluginLoc);
  bool status = true;

  for each (Type^ type in pluginAsm->GetTypes())
  {
    MethodInfo ^method = type->GetMethod("Register", BindingFlags::Static | BindingFlags::Public | BindingFlags::NonPublic,
      nullptr, gcnew array<Type^>(1){Gst::Plugin::typeid}, nullptr);
    if (method != nullptr && method->IsStatic && method->ReturnType == bool::typeid)
      status &= (bool)method->Invoke(nullptr, gcnew array<Object^>(1){gcnew Gst::Plugin(System::IntPtr(plugin))});
  }

  return status;
}

GST_PLUGIN_DEFINE (
    GST_VERSION_MAJOR,
    GST_VERSION_MINOR,
    "csharppluginwrapper",
    "Wrapper for C# plugins",
    wrapper_init,
    "Compiled " __DATE__ " " __TIME__,
    GST_LICENSE_UNKNOWN,
    "",
    "http://code.google.com/p/ossbuild-vs2010/"
)