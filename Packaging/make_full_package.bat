:: Copies all the compiled plugins and binaries to the 'Deployment' folder,
:: in a structure suitable for distribution.

call lib\env.bat

mkdir %PKGDIR%\bin
mkdir %PKGDIR%\bin\plugins
mkdir %PKGDIR%\lib
copy %BINDIR%\*.exe %PKGDIR%\bin
copy %BINDIR%\*.dll %PKGDIR%\bin
copy %BINDIR%\plugins\*.dll %PKGDIR%\bin\plugins
copy %MYDIR%\example_scripts\* %PKGDIR%
copy %SHAREDDIR%\Build\Windows\Win32\bin\*.dll %PKGDIR%\lib

@echo "Now running basic sanity check"
cd %PKGDIR%
.\list_plugins.bat

pause
