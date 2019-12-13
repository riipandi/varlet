@echo off
color 08

set ROOT=%~dp0
set CURL=%ROOT%\utils\curl.exe
set UNZIP=%ROOT%\utils\7za.exe
set TMPDIR=%ROOT%\_tmpdir
set ODIR=%ROOT%\_dst64
set STUB=%ROOT%\stubs

:: ---------------------------------------------------------------------------------------------------------------------
set "ver_composer=1.9.1"
set "ver_httpd=2.4.41"
set "ver_nginx=1.17.6"
set "ver_openssl=1.1.1e"
set "ver_php72=7.2.25"
set "ver_php73=7.3.12"
set "ver_php74=7.4.0"
set "ver_imagick=7.0.7-11"
set "ver_php_imagick=3.4.3"
set "ver_php_phalcon=3.4.5"
set "ver_phpredis=5.1.1"
set "ver_xdebug=2.8.0"
set "ver_mkcert=1.4.1"
set "ver_adminer=4.7.5"
set "ver_mailhog=1.0.0"
set "ver_mhsendmail=0.2.0"

:: Download link
set "url_php72=https://windows.php.net/downloads/releases/php-%ver_php72%-Win32-VC15-x64.zip"
set "url_php73=https://windows.php.net/downloads/releases/php-%ver_php73%-Win32-VC15-x64.zip"
set "url_php74=https://windows.php.net/downloads/releases/php-%ver_php74%-Win32-vc15-x64.zip"

set "url_phalcon_php72=https://github.com/phalcon/cphalcon/releases/download/v%ver_php_phalcon%/phalcon_x64_vc15_php7.2_%ver_php_phalcon%-4250.zip"
set "url_phalcon_php73=https://github.com/phalcon/cphalcon/releases/download/v%ver_php_phalcon%/phalcon_x64_vc15_php7.3_%ver_php_phalcon%-4250.zip"

set "url_imagick_php72=https://windows.php.net/downloads/pecl/snaps/imagick/%ver_php_imagick%/php_imagick-%ver_php_imagick%-7.2-ts-vc15-x64.zip"
set "url_imagick_php73=https://windows.php.net/downloads/pecl/snaps/imagick/%ver_php_imagick%/php_imagick-%ver_php_imagick%-7.3-ts-vc15-x64.zip"
set "url_imagick_php74=https://windows.php.net/downloads/pecl/snaps/imagick/%ver_php_imagick%/php_imagick-%ver_php_imagick%-7.4-ts-vc15-x64.zip"

set "url_phpredis_php72=https://windows.php.net/downloads/pecl/releases/redis/%ver_phpredis%/php_redis-%ver_phpredis%-7.2-ts-vc15-x64.zip"
set "url_phpredis_php73=https://windows.php.net/downloads/pecl/releases/redis/%ver_phpredis%/php_redis-%ver_phpredis%-7.3-ts-vc15-x64.zip"
set "url_phpredis_php74=https://windows.php.net/downloads/pecl/releases/redis/%ver_phpredis%/php_redis-%ver_phpredis%-7.4-ts-vc15-x64.zip"

set "url_xdebug_php72=https://xdebug.org/files/php_xdebug-%ver_xdebug%beta2-7.2-vc15-x86_64.dll"
set "url_xdebug_php73=https://xdebug.org/files/php_xdebug-%ver_xdebug%-7.3-vc15-x86_64.dll"
set "url_xdebug_php74=https://xdebug.org/files/php_xdebug-%ver_xdebug%-7.4-vc15-x86_64.dll"

:: ---------------------------------------------------------------------------------------------------------------------
:menu
for /F "tokens=1,2 delims=#" %%a in ('"prompt #$H#$E# & echo on & for %%b in (1) do rem"') do (set "DEL=%%a")
<nul set /p=""
call :PainText 02 "=====================================================" && echo. &
call :PainText 02 "=  1 - Build setup files       c - Clean packages    " && echo. &
call :PainText 02 "=  2 - Compile varlet app      r - Run installer     " && echo. &
call :PainText 02 "=  3 - Compile installer       x - Exit              " && echo. &
call :PainText 02 "====================================================="
goto :choice

:PainText
<nul set /p "=%DEL%" > "%~2"
findstr /v /a:%1 /R "+" "%~2" nul
del "%~2" > nul
goto :eof

:choice
echo. && set /P c="What do you want to do?: "
for /F "tokens=*" %%i in ('%ROOT%\utils\sigcheck.exe -nobanner -q -n %ROOT%\_dst64\VarletUi.exe') do set ver_varlet=%%i
if /I "%c%" EQU "r" ("%ROOT%\_output\varlet-%ver_varlet%-x64.exe")
if /I "%c%" EQU "c" goto :clean_packages
if /I "%c%" EQU "1" goto :build_setup
if /I "%c%" EQU "2" goto :compile_app
if /I "%c%" EQU "3" goto :compile_inno
if /I "%c%" EQU "x" goto :quit
goto :choice

:: ---------------------------------------------------------------------------------------------------------------------
:build_setup
if not exist "%ODIR%" mkdir "%ODIR%" 2> NUL
if not exist "%TMPDIR%" mkdir "%TMPDIR%" 2> NUL
if not exist "%ODIR%\utils" mkdir "%ODIR%\utils" 2> NUL

call %ROOT%\scripts\get_apache.bat
call %ROOT%\scripts\get_php72.bat
call %ROOT%\scripts\get_php73.bat
call %ROOT%\scripts\get_php73.bat
call %ROOT%\scripts\get_ioncube.bat
call %ROOT%\scripts\get_imagick.bat
call %ROOT%\scripts\get_essential.bat

echo. && echo ^> Include extra utilities ...
copy /Y "%ROOT%\utils\7za.dll" "%ODIR%\utils\7za.dll" > nul
copy /Y "%ROOT%\utils\7za.exe" "%ODIR%\utils\7za.exe" > nul
copy /Y "%ROOT%\utils\7zxa.dll" "%ODIR%\utils\7zxa.dll" > nul
copy /Y "%ROOT%\utils\curl.exe" "%ODIR%\utils\curl.exe" > nul
copy /Y "%ROOT%\utils\curl-ca-bundle.crt" "%ODIR%\utils\curl-ca-bundle.crt" > nul
copy /Y "%ROOT%\utils\libcurl-x64.dll" "%ODIR%\utils\libcurl-x64.dll" > nul

echo. && echo ^> Include the stubs ...
copy /Y "%STUB%\config\php.ini" "%ODIR%\pkg\php\php-7.2-ts\php.ini" > nul
copy /Y "%STUB%\config\php.ini" "%ODIR%\pkg\php\php-7.3-ts\php.ini" > nul
copy /Y "%ROOT%\include\varlet-license.txt" "%ODIR%\license.txt" > nul
copy /Y "%ROOT%\credits.txt" "%ODIR%\credits.txt" > nul
xcopy "%STUB%\htdocs" "%ODIR%\www" /E /I /Y > nul
xcopy "%STUB%\opt" "%ODIR%\opt" /E /I /Y > nul

echo. && goto :menu

:: ---------------------------------------------------------------------------------------------------------------------
:compile_app
if not exist "%TMPDIR%\JetMSBuild" (
  echo. && echo ^> Installing JetBrains MSBuild ...
  if not exist "%TMP%\JetMSBuild.zip" ( %CURL% -L# "https://jb.gg/msbuild" -o "%TMP%\JetMSBuild.zip" )
  if exist "%TMP%\JetMSBuild.zip" ( %UNZIP% x "%TMP%\JetMSBuild.zip" -o"%TMPDIR%\JetMSBuild" -y > nul )
)

if not exist "%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" (
  echo. && echo ^> Installing Visual Studio Build Tools ...
  if not exist "%TMPDIR%\vs_BuildTools.exe" (
    %CURL% -L# "https://download.visualstudio.microsoft.com/download/pr/c7d8bceb-64c4-426d-85a2-89bc21b21245/1f07eb88f128370a60ab6d592b1e0f3deb76036a168c7e3021d0fbaf4316a5a0/vs_BuildTools.exe" -o "%TMPDIR%\vs_BuildTools.exe"
  )
  if exist "%TMPDIR%\vs_BuildTools.exe" ( "%TMPDIR%\vs_BuildTools.exe" --add Microsoft.VisualStudio.Workload.MSBuildTools )
)

if not exist "%ROOT%\source\packages" (
  if exist "%ROOT%\source\VarletCli\packages.config" (
    echo. && echo ^> Installing Nuget packages ...
    "%ROOT%\utils\nuget.exe" install "%ROOT%\source\VarletCli\packages.config" -OutputDirectory "%ROOT%\source\packages" > nul
    "%ROOT%\utils\nuget.exe" install "%ROOT%\source\VarletUi\packages.config" -OutputDirectory "%ROOT%\source\packages" > nul
  )
)

echo. && echo ^> Compiling Varlet App ... && echo.
for %%i in ("VarletUi.exe", "varlet.exe") do ( taskkill /f /im %%i>NUL 2>&1 )
if exist "%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild" (
  "%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" "%ROOT%\source\Varlet.sln" /p:Configuration=Release /verbosity:minimal -nologo
) else (
  "%TMPDIR%\JetMSBuild\MSBuild\15.0\Bin\MSBuild.exe" "%ROOT%\source\Varlet.sln" /p:Configuration=Release /verbosity:minimal -nologo
)
for /R "%ODIR%" %%G in (*.pdb) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (*.exe.config) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (INIFileParser*.xml) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (Semver*.xml) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (Serilog*.xml) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (McMaster*.xml) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (System.ValueTuple*.xml) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (varlet*.json) do "cmd /c del /F %%G"
for /R "%ODIR%" %%G in (varlet*.ini) do "cmd /c del /F %%G"

:: for quick debugging
REM if exist "%HOMEDRIVE%\Varlet" (
REM   copy /Y "%ODIR%\VarletUi.exe" "%HOMEDRIVE%\Varlet.exe" > nul
REM   copy /Y "%ODIR%\utils\varlet.exe" "%HOMEDRIVE%\utils\varlet.exe" > nul
REM )
echo. && goto :menu

:: ---------------------------------------------------------------------------------------------------------------------
:compile_inno
echo. && echo ^> Compiling installer files ...
for /R "%ODIR%" %%G in (*.pdb) do "cmd /c del /F %%G"
"%programfiles(x86)%\Inno Setup 6\ISCC.exe" /Qp "%ROOT%\installer.iss"

echo. && echo ^> Compressing varlet portable ...
for /F "tokens=*" %%i in ('%ROOT%\utils\sigcheck.exe -nobanner -q -n %ROOT%\_dst64\VarletUi.exe') do set ver_varlet=%%i
if exist "%ROOT%\_output\varlet-%ver_varlet%-x64.7z" ( del /F "%ROOT%\_output\varlet-%ver_varlet%-x64.7z" )
%UNZIP% a -r -bsp1 -t7z "%ROOT%\_output\varlet-%ver_varlet%-x64.7z" "%ROOT%\_dst64"
%UNZIP% rn "%ROOT%\_output\varlet-%ver_varlet%-x64.7z" _dst64 varlet
echo. && echo. && echo Setup file has been created!
echo. && goto :menu

:: ---------------------------------------------------------------------------------------------------------------------
:clean_packages
echo. && echo ^> Removing old packages ...
if exist "%TMPDIR%" RD /S /Q "%TMPDIR%"
if exist "%ODIR%" RD /S /Q "%ODIR%"
echo. && goto :menu

:: ---------------------------------------------------------------------------------------------------------------------
:quit
echo. && echo ^> Done, good bye. && echo.
