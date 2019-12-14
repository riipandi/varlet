@echo off
color 08

:: PHP v7.4
if not exist "%TMPDIR%\php-%ver_php74%.zip" (
  echo. && echo ^> Downloading PHP v%ver_php74% ...
  %CURL% -L# %url_php74% -o "%TMPDIR%\php-%ver_php74%.zip"
  %CURL% -L# %url_xdebug_php74% -o "%TMPDIR%\php74_xdebug.dll"
  %CURL% -L# %url_phpredis_php74% -o "%TMPDIR%\php74_redis.zip"
  %CURL% -L# %url_imagick_php74% -o "%TMPDIR%\imagick-%ver_php_imagick%-php74.zip"
  REM %CURL% -L# %url_phalcon_php74% -o "%TMPDIR%\phalcon-%ver_php74%-php74.zip"
)
if exist "%TMPDIR%\php-%ver_php74%.zip" (
  echo. && echo ^> Extracting PHP v%ver_php74% ...
  if exist "%ODIR%\pkg\php\php-7.4-ts" RD /S /Q "%ODIR%\pkg\php\php-7.4-ts"
  %UNZIP% x "%TMPDIR%\php-%ver_php74%.zip" -o"%ODIR%\pkg\php\php-7.4-ts" -y > nul
  copy /Y "%TMPDIR%\php74_xdebug.dll" "%ODIR%\pkg\php\php-7.4-ts\ext\php_xdebug.dll" > nul

  %UNZIP% x "%TMPDIR%\php74_redis.zip" -o"%TMPDIR%" -y > nul
  copy /Y "%TMPDIR%\php_redis.dll" "%ODIR%\pkg\php\php-7.4-ts\ext\php_redis.dll" > nul
  del /F "%TMPDIR%\php_redis.dll"

  %UNZIP% x "%TMPDIR%\imagick-%ver_php_imagick%-php74.zip" -o"%TMPDIR%\imagick_php74" -y > nul
  copy /Y "%TMPDIR%\imagick_php74\php_imagick.dll" "%ODIR%\pkg\php\php-7.4-ts\ext\php_imagick.dll" > nul

  REM %UNZIP% x "%TMPDIR%\phalcon-%ver_php74%-php74.zip" -o"%TMPDIR%\phalcon74" -y > nul
  REM copy /Y "%TMPDIR%\phalcon74\php_phalcon.dll" "%ODIR%\pkg\php\php-7.4-ts\ext\php_phalcon.dll" > nul

  copy /Y "%STUB%\config\php.ini" "%ODIR%\pkg\php\php-7.4-ts\php.ini" > nul
)
