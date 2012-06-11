This is an example of how to create a GStreamer plugin using C#.
In addition, a C++ wrapper is provided to make the plugin accessible to
gst-launch and gst-inspect (and any other program also).

You don't need PluginWrapper if you only use your plugin from your own program.
Also, the same PluginWrapper binary can be used for different plugins by just
renaming it. If its own name is 'MyPlugin.wrap.dll', it automatically finds the
real plugin as 'MyPlugin.dll'.

To compile you need the 'gstreamer' and 'gstreamer-sdk' folders from the ossbuild-vs2010
downloads. Extract them under csharp-plugin-example.

