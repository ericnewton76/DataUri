@ECHO OFF
setlocal

REM initialization
set PACKAGES_ROOT=%~dp0packages
set NUGET_EXE=%PACKAGES_ROOT%\Nuget.Commandline.2.8.6\tools\nuget.exe
nuget 1>NUL 2>NUL
if errorlevel 0 if not errorlevel 255 echo using nuget from path & set NUGET_EXE=nuget

REM appveyor
if not "%APPVEYOR_BUILD_VERSION%" == "" set BUILD_VERSION=%APPVEYOR_BUILD_VERSION%
if not "%APPVEYOR_BUILD_VERSION%" == "" echo using nuget from Appveyor environment & set NUGET_EXE=nuget

REM checks
if "%BUILD_VERSION%" == "" echo Missing BUILD_VERSION & set FAIL=true

REM try install
%NUGET_EXE% install
if errorlevel 0 if not errorlevel 1 goto :NUGET_PACKAGES_INSTALLED
if not "%NUGET_EXE%" == "nuget" if not exist "%NUGET_EXE%" echo Missing Nuget.Commandline.2.8.6 in packages, run Nuget Install & set FAIL=true
if "%FAIL%" == "true" goto :END

:NUGET_PACKAGES_INSTALLED

mkdir Build 2>NUL

if "%1" == "--after-build" goto :SKIP_BUILD

echo.
if "%1" == "--no-msbuild" goto :SKIP_BUILD
call .\build.cmd & if errorlevel 1 goto :END
shift

:SKIP_BUILD

REM Create Nuget Package
pushd Build

xcopy ..\src\DataUri\bin\Release Release\ /s /y
copy ..\DataUri.nuspec

echo %NUGET_EXE% pack DataUri.nuspec -version %BUILD_VERSION%
%NUGET_EXE% pack DataUri.nuspec -version %BUILD_VERSION%
popd

REM if not "%1" == "--no-deploy" %NUGET_EXE% push
shift

:END

