:: Creates an SDK directory with the include files & .libs that are not included in
:: in the main package.

call lib\env.bat

set PKGDIR=%DEPLOYMENTDIR%\gstreamer-sdk
rmdir /S /Q "%PKGDIR%"
mkdir "%PKGDIR%"

mkdir "%PKGDIR%\lib"
mkdir "%PKGDIR%\include"
xcopy /s "%BINDIR%\..\include\gstreamer-0.10\*" "%PKGDIR%\include"
copy "%BINDIR%\..\lib\*" "%PKGDIR%\lib"

set DEPSDIR=%SHAREDDIR%\Build\Windows\Win32
xcopy /s "%DEPSDIR%\include\*" "%PKGDIR%\include"
copy "%DEPSDIR%\lib\*.lib" "%PKGDIR%\lib"

:: Some includes have unnecessary subdirs, get rid of that
set MVLIBS=atk-1.0 freetype2 gail-1.0 gdk-pixbuf-2.0 gio-win32-2.0 glib-2.0 gtk-2.0 ^
           gtkgl-2.0 libcroco-0.6 libgsf-1 liboil-0.3 librsvg-2.0 libsoup-2.4 libxml2 ^
		   orc-0.4 pango-1.0 schroedinger-1.0
for %%i in (%MVLIBS%) do (
	xcopy /s "%PKGDIR%\include\%%i\*" "%PKGDIR%\include\"
	rmdir /S /Q "%PKGDIR%\include\%%i"
)

