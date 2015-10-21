@ECHO OFF
setlocal

set NUGET_EXE=..\packages\Nuget.Commandline.2.8.6\tools\nuget.exe
if "%BUILD_VERSION%" == "" echo Missing BUILD_VERSION & goto :END

echo.
if not "%1" == "--no-msbuild" call .\build.cmd & if errorlevel 1 goto :END
shift


pushd Build
%NUGET_EXE% pack ..\DataUri.nuspec -version %BUILD_VERSION%

if not "%1" == "--no-deploy" %NUGET_EXE% 
shift

:END
popd
