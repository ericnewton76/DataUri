@ECHO OFF
setlocal
set PROJECT_NAME=DataUri

msbuild src\%PROJECT_NAME%\%PROJECT_NAME%.csproj /p:OutputPath=..\..\Build\%PROJECT_NAME%
