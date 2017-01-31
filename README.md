# DataUri

[![Build status](https://ci.appveyor.com/api/projects/status/l0ii5t8tvsdsrmw5?svg=true)](https://ci.appveyor.com/project/EricNewton/datauri)
[![Nuget](https://img.shields.io/nuget/v/DataUri.svg)](https://nuget.org/packages/DataUri)

Nuget
Install-Package DataUri

Parses Data Uris.

.cssclass
{
  url(data:base64,ABCDEFGHIJKLMNOPQRSTUVWXYZ==)
}

returns a DataUri class that has:
  ImageBytes property, the binary bytes
  
  
