set OLDDIR=%CD%..
set MYDIR=%~dp0..
set ROOTDIR=%MYDIR%\..
set SDKDIR=%ROOTDIR%\SDKs
set MAINDIR=%ROOTDIR%\Main
set TOOLSDIR=%ROOTDIR%\Tools
set BUILDDIR=%ROOTDIR%\Build
set SHAREDDIR=%ROOTDIR%\Shared
set PACKAGINGDIR=%ROOTDIR%\Packaging
set LIBRARIESDIR=%ROOTDIR%\Libraries
set DEPLOYMENTDIR=%ROOTDIR%\Deployment
set PROPERTIESDIR=%ROOTDIR%\Properties
set BINDIR=%BUILDDIR%\Windows\Win32\Release\bin

cd /d "%MYDIR%"

