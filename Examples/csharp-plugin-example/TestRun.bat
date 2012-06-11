call gstreamer\env.bat
gst-launch --gst-plugin-load=Build\MyPlugin.wrap.dll ^
	videotestsrc ! myplugin ! colorspace ! autovideosink
