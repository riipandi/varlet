@echo off
color 08

:: PHP v7.3
if not exist "%TMPDIR%\php-%ver_php73%.zip" (
  echo. && echo ^> Downloading PHP v%ver_php73% ...
  %CURL% -L# %url_php73% -o "%TMPDIR%\php-%ver_php73%.zip"
  %CURL% -L# %url_xdebug_php73% -o "%TMPDIR%\php73_xdebug.dll"
  %CURL% -L# %url_phpredis_php73% -o "%TMPDIR%\php73_redis.zip"
  %CURL% -L# %url_imagick_php73% -o "%TMPDIR%\imagick-%ver_php_imagick%-php73.zip"
  %CURL% -L# %url_phalcon_php73% -o "%TMPDIR%\phalcon-%ver_php73%-php73.zip"
)
if exist "%TMPDIR%\php-%ver_php73%.zip" (
  echo. && echo ^> Extracting PHP v%ver_php73% ...
  if exist "%ODIR%\pkg\php\php-7.3-ts" RD /S /Q "%ODIR%\pkg\php\php-7.3-ts"
  %UNZIP% x "%TMPDIR%\php-%ver_php73%.zip" -o"%ODIR%\pkg\php\php-7.3-ts" -y > nul
  copy /Y "%TMPDIR%\php73_xdebug.dll" "%ODIR%\pkg\php\php-7.3-ts\ext\php_xdebug.dll" > nul

  %UNZIP% x "%TMPDIR%\phalcon-%ver_php73%-php73.zip" -o"%TMPDIR%\phalcon73" -y > nul
  copy /Y "%TMPDIR%\phalcon73\php_phalcon.dll" "%ODIR%\pkg\php\php-7.3-ts\ext\php_phalcon.dll" > nul

  %UNZIP% x "%TMPDIR%\php73_redis.zip" -o"%TMPDIR%" -y > nul
  copy /Y "%TMPDIR%\php_redis.dll" "%ODIR%\pkg\php\php-7.3-ts\ext\php_redis.dll" > nul
  del /F "%TMPDIR%\php_redis.dll"

  %UNZIP% x "%TMPDIR%\imagick-%ver_php_imagick%-php73.zip" -o"%TMPDIR%\imagick_php73" -y > nul
  copy /Y "%TMPDIR%\imagick_php73\php_imagick.dll" "%ODIR%\pkg\php\php-7.3-ts\ext\php_imagick.dll" > nul

  copy /Y "%STUB%\config\php.ini" "%ODIR%\pkg\php\php-7.3-ts\php.ini" > nul
)
