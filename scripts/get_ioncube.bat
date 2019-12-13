@echo off
color 08

:: ionCube Loader VC15
if not exist "%TMPDIR%\ioncube-vc15.zip" (
  echo. && echo ^> Downloading ionCube loader ...
  %CURL% -L# "https://downloads.ioncube.com/loader_downloads/ioncube_loaders_win_vc15_x86-64.zip" -o "%TMPDIR%\ioncube-vc15.zip"
)
if exist "%TMPDIR%\ioncube-vc15.zip" (
  echo. && echo ^> Extracting ionCube loader ...
  if exist "%TMPDIR%\ioncube" RD /S /Q "%TMPDIR%\ioncube"
  %UNZIP% x "%TMPDIR%\ioncube-vc15.zip" -o"%TMPDIR%" -y > nul
  copy /Y "%TMPDIR%\ioncube\ioncube_loader_win_7.2.dll" "%ODIR%\pkg\php\php-7.2-ts\ext\php_ioncube.dll" > nul
  copy /Y "%TMPDIR%\ioncube\ioncube_loader_win_7.3.dll" "%ODIR%\pkg\php\php-7.3-ts\ext\php_ioncube.dll" > nul
)
