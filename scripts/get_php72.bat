@echo off
color 08

:: PHP v7.2
if not exist "%TMPDIR%\php-%ver_php72%.zip" (
  echo. && echo ^> Downloading PHP v%ver_php72% ...
  %CURL% -L# %url_php72% -o "%TMPDIR%\php-%ver_php72%.zip"
  %CURL% -L# %url_xdebug_php72% -o "%TMPDIR%\php72_xdebug.dll"
  %CURL% -L# %url_phpredis_php72% -o "%TMPDIR%\php72_redis.zip"
  %CURL% -L# %url_imagick_php72% -o "%TMPDIR%\imagick-%ver_php_imagick%-php72.zip"
  %CURL% -L# %url_phalcon_php72% -o "%TMPDIR%\phalcon-%ver_php72%-php72.zip"
)
if exist "%TMPDIR%\php-%ver_php72%.zip" (
  echo. && echo ^> Extracting PHP v%ver_php72% ...
  if exist "%ODIR%\pkg\php\php-7.2-ts" RD /S /Q "%ODIR%\pkg\php\php-7.2-ts"
  %UNZIP% x "%TMPDIR%\php-%ver_php72%.zip" -o"%ODIR%\pkg\php\php-7.2-ts" -y > nul
  copy /Y "%TMPDIR%\php72_xdebug.dll" "%ODIR%\pkg\php\php-7.2-ts\ext\php_xdebug.dll" > nul

  %UNZIP% x "%TMPDIR%\phalcon-%ver_php72%-php72.zip" -o"%TMPDIR%\phalcon72" -y > nul
  copy /Y "%TMPDIR%\phalcon72\php_phalcon.dll" "%ODIR%\pkg\php\php-7.2-ts\ext\php_phalcon.dll" > nul

  %UNZIP% x "%TMPDIR%\php72_redis.zip" -o"%TMPDIR%" -y > nul
  copy /Y "%TMPDIR%\php_redis.dll" "%ODIR%\pkg\php\php-7.2-ts\ext\php_redis.dll" > nul
  del /F "%TMPDIR%\php_redis.dll"

  %UNZIP% x "%TMPDIR%\imagick-%ver_php_imagick%-php72.zip" -o"%TMPDIR%\imagick_php72" -y > nul
  copy /Y "%TMPDIR%\imagick_php72\php_imagick.dll" "%ODIR%\pkg\php\php-7.2-ts\ext\php_imagick.dll" > nul

  copy /Y "%STUB%\config\php.ini" "%ODIR%\pkg\php\php-7.2-ts\php.ini" > nul
)
