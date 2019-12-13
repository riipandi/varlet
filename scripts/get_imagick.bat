@echo off
color 08

:: ImageMagick
if not exist "%TMPDIR%\imagick-%ver_imagick%.zip" (
  echo. && echo ^> Downloading ImageMagick v%ver_imagick% ...
  %CURL% -L# "http://windows.php.net/downloads/pecl/deps/ImageMagick-%ver_imagick%-vc15-x64.zip" -o "%TMPDIR%\imagick-%ver_imagick%.zip"
)
if exist "%TMPDIR%\imagick-%ver_imagick%.zip" (
  echo. && echo ^> Extracting ImageMagick v%ver_imagick% ...
  if exist "%ODIR%\pkg\imagick" RD /S /Q "%ODIR%\pkg\imagick"
  %UNZIP% x "%TMPDIR%\imagick-%ver_imagick%.zip" -o"%ODIR%\pkg\imagick" -y > nul
)
