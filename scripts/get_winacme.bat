@echo off
color 08

:: ionCube Loader VC15
if not exist "%TMPDIR%\win-acme-x64.zip" (
  echo. && echo ^> Downloading ionCube loader ...
  %CURL% -L# "https://github.com/PKISharp/win-acme/releases/download/v%ver_winacme%/win-acme.v%ver_winacme%.x64.pluggable.zip" -o "%TMPDIR%\win-acme-x64.zip"
)
if exist "%TMPDIR%\win-acme-x64.zip" (
  echo. && echo ^> Extracting Win ACME x64 ...
  if exist "%ODIR%\pkg\winacme" RD /S /Q "%ODIR%\pkg\winacme"
  %UNZIP% x "%TMPDIR%\win-acme-x64.zip" -o"%ODIR%\pkg\winacme" -y > nul
)
