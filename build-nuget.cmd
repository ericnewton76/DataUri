@ECHO OFF
setlocal

set NUGET_EXE=..\packages\Nuget.Commandline.2.8.6\tools\nuget.exe
if "%BUILD_VERSION%" == "" echo Missing BUILD_VERSION & goto :END

if "%1" == "--after-build" goto :SKIP_BUILD

echo.
if "%1" == "--no-msbuild" goto :SKIP_BUILD
call .\build.cmd & if errorlevel 1 goto :END
shift

:SKIP_BUILD
pushd Build
%NUGET_EXE% pack ..\DataUri.nuspec -version %BUILD_VERSION%

if not "%1" == "--no-deploy" %NUGET_EXE% 
shift

:END
popd
