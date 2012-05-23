:: This file lists all the elements in the GStreamer package.
:: It uses a minimal PATH so it doesn't accidentally list files
:: installed elsewhere in the system.

set PATH=C:\windows
call env.bat

gst-inspect > list-of-elements.txt
