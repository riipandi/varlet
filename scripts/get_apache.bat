@echo off
color 08

:: Apache HTTP Server
if not exist "%TMPDIR%\httpd-%ver_httpd%.zip" (
  echo. && echo ^> Downloading Apache HTTP Server v%ver_httpd% ...
  %CURL% -L# "https://home.apache.org/~steffenal/VC15/binaries/httpd-%ver_httpd%-win64-VC15.zip" -o "%TMPDIR%\httpd-%ver_httpd%.zip"
)
if exist "%TMPDIR%\httpd-%ver_httpd%.zip" (
  echo. && echo ^> Extracting Apache HTTP Server v%ver_httpd% ...
  if exist "%ODIR%\pkg\httpd" RD /S /Q "%ODIR%\pkg\httpd"
  if exist "%TMPDIR%\Apache24" RD /S /Q "%TMPDIR%\Apache24"
  %UNZIP% x "%TMPDIR%\httpd-%ver_httpd%.zip" -o"%TMPDIR%" -y > nul
  xcopy %TMPDIR%\Apache24 %ODIR%\pkg\httpd /E /I /Y > nul
  RD /S /Q "%ODIR%\pkg\httpd\bin\iconv"
  RD /S /Q "%ODIR%\pkg\httpd\conf"
  RD /S /Q "%ODIR%\pkg\httpd\error"
  RD /S /Q "%ODIR%\pkg\httpd\htdocs"
  RD /S /Q "%ODIR%\pkg\httpd\icons"
  RD /S /Q "%ODIR%\pkg\httpd\include"
  RD /S /Q "%ODIR%\pkg\httpd\logs"
  RD /S /Q "%ODIR%\pkg\httpd\lib"
  RD /S /Q "%ODIR%\pkg\httpd\manual"
  xcopy %STUB%\httpd\conf %ODIR%\pkg\httpd\conf /E /I /Y > nul
)
