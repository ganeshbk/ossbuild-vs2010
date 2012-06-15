:: Copies all the compiled plugins and binaries to the 'Deployment' folder,
:: in a structure suitable for distribution.

call lib\env.bat

set PKGDIR=%DEPLOYMENTDIR%\gstreamer
rmdir /S /Q "%PKGDIR%"
mkdir "%PKGDIR%"

mkdir "%PKGDIR%\bin"
mkdir "%PKGDIR%\bin\plugins"
mkdir "%PKGDIR%\lib"
copy "%BINDIR%\*.exe" "%PKGDIR%\bin"
copy "%BINDIR%\*.dll" "%PKGDIR%\bin"
copy "%BINDIR%\plugins\*.dll" "%PKGDIR%\bin\plugins"
copy "%MYDIR%\example_scripts\*" "%PKGDIR%"
copy "%SHAREDDIR%\Build\Windows\Win32\bin\*.dll" "%PKGDIR%\lib"

:: Python DLLs cause errors if Python is not installed on target computer
:: Move them to subdir for this reason.
mkdir "%PKGDIR%\bin\python"
move "%PKGDIR%\bin\plugins\libgstpython*" "%PKGDIR%\bin\python"

:: Keep all dependencies in lib folder, remove duplicates from bin folder.
for /f %%i in ('"dir /b %PKGDIR%\lib"') do (
	if exist "%PKGDIR%\bin\%%i" (
		del "%PKGDIR%\bin\%%i"
	)
)

:: Depending on whether you are using GPL or LGPL build, remove unnecessary libs
del "%PKGDIR%\lib\*-gpl*"
del "%PKGDIR%\bin\plugins\*-gpl*"

@echo "Now running basic sanity check"
cd "%PKGDIR%"
.\list_plugins.bat

pause
