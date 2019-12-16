@echo off
color 08

:: VCRedist 2012 + 2015-2019
set "URL_VCREDIST_1519=https://aka.ms/vs/16/release/VC_redist.x64.exe"
set "URL_VCREDIST_2012=https://download.microsoft.com/download/1/6/B/16B06F60-3B20-4FF2-B699-5E9B7962F9AE/VSU_4/vcredist_x64.exe"
if not exist "%TMPDIR%\vcredis\" (
  echo. && echo ^> Downloading Visual C++ Redistributable ...
  if not exist "%TMPDIR%\vcredis" mkdir "%TMPDIR%\vcredis" 2> NUL
  %CURL% -L# %URL_VCREDIST_2012% -o "%TMPDIR%\vcredis\vcredis2012x64.exe"
  %CURL% -L# %URL_VCREDIST_1519% -o "%TMPDIR%\vcredis\vcredis1519x64.exe"
)

:: Mailhog + mhsendmail
if not exist "%TMPDIR%\mailhog.exe" (
  echo. && echo ^> Downloading Mailhog v%ver_mailhog% ...
  %CURL% -L# "https://github.com/mailhog/MailHog/releases/download/v%ver_mailhog%/MailHog_windows_amd64.exe" -o "%TMPDIR%\mailhog.exe"
  %CURL% -L# "https://github.com/mailhog/mhsendmail/releases/download/v%ver_mhsendmail%/mhsendmail_windows_amd64.exe" -o "%TMPDIR%\mhsendmail.exe"
)
if exist "%TMPDIR%\mailhog.exe" (
  echo. && echo ^> Extracting Mailhog v%ver_mailhog% ...
  if not exist "%ODIR%\pkg\mailhog" mkdir "%ODIR%\pkg\mailhog" 2> NUL
  copy /Y "%TMPDIR%\mailhog.exe" "%ODIR%\pkg\mailhog\mailhog.exe" > nul
  copy /Y "%TMPDIR%\mhsendmail.exe" "%ODIR%\pkg\mailhog\mhsendmail.exe" > nul
  copy /Y "%STUB%\config\mailhogservice.xml" "%ODIR%\pkg\mailhog\mailhogservice.xml" > nul
  copy /Y "%ROOT%\utils\winsw.exe" "%ODIR%\pkg\mailhog\mailhogservice.exe" > nul
)

:: Composer
if not exist "%TMPDIR%\composer.phar" (
  echo. && echo ^> Downloading Composer v%ver_composer% ...
  %CURL% -L# "https://getcomposer.org/download/%ver_composer%/composer.phar" -o "%TMPDIR%\composer.phar"
)
if exist "%TMPDIR%\composer.phar" ( copy /Y "%TMPDIR%\composer.phar" "%ODIR%\utils\composer.phar" > nul )

:: Adminer
if not exist "%ODIR%\opt\adminer" (
  mkdir "%ODIR%\opt\adminer" 2> NUL
  echo. && echo ^> Downloading Adminer v%ver_adminer% ...
  copy /Y "%STUB%\opt\adminer\index.php" "%ODIR%\opt\adminer\index.php" > nul
  %CURL% -Ls "https://github.com/vrana/adminer/releases/download/v%ver_adminer%/adminer-%ver_adminer%-en.php" -o "%ODIR%\opt\adminer\adminer.php"
  %CURL% -Ls "https://raw.githubusercontent.com/vrana/adminer/master/designs/rmsoft/adminer.css" -o "%ODIR%\opt\adminer\adminer.css"
  if not exist "%ODIR%\opt\adminer\plugins" mkdir "%ODIR%\opt\adminer\plugins" 2> NUL
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/plugin.php" -o "%ODIR%\opt\adminer\plugin.php"
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/foreign-system.php" -o "%ODIR%\opt\adminer\plugins\foreign-system.php"
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/login-servers.php" -o "%ODIR%\opt\adminer\plugins\login-servers.php"
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/database-hide.php" -o "%ODIR%\opt\adminer\plugins\database-hide.php"
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/edit-foreign.php" -o "%ODIR%\opt\adminer\plugins\edit-foreign.php"
  %CURL% -Ls "https://raw.github.com/vrana/adminer/master/plugins/dump-zip.php" -o "%ODIR%\opt\adminer\plugins\dump-zip.php"
)

:: mkcert
if not exist "%TMPDIR%\mkcert.exe" (
  echo. && echo ^> Downloading mkcert v%ver_mkcert% ...
  %CURL% -L# "https://github.com/FiloSottile/mkcert/releases/download/v%ver_mkcert%/mkcert-v%ver_mkcert%-windows-amd64.exe" -o "%TMPDIR%\mkcert.exe"
)
if exist "%TMPDIR%\mkcert.exe" ( copy /Y "%TMPDIR%\mkcert.exe" "%ODIR%\utils\mkcert.exe" > nul )

:: Acrylic DNS
if not exist "%TMPDIR%\acrylicdns.zip" (
  echo. && echo ^> Downloading Acrylic DNS v%ver_acrylicdns% ...
  %CURL% -L# "https://excellmedia.dl.sourceforge.net/project/acrylic/Acrylic/%ver_acrylicdns%/Acrylic-Portable.zip" -o "%TMPDIR%\acrylicdns.zip"
)
if exist "%TMPDIR%\acrylicdns.zip" (
  echo. && echo ^> Extracting Acrylic DNS v%ver_acrylicdns% ...
  if exist "%ODIR%\pkg\acrylicdns" RD /S /Q "%ODIR%\pkg\acrylicdns"
  %UNZIP% x "%TMPDIR%\acrylicdns.zip" -o"%ODIR%\pkg\acrylicdns" -y > nul
  copy /Y "%STUB%\config\AcrylicConfiguration.ini" "%ODIR%\pkg\acrylicdns\AcrylicConfiguration.ini" > nul
)

:: ngrok
if not exist "%TMPDIR%\ngrok-amd64.zip" (
  echo. && echo ^> Downloading Ngrok ...
  %CURL% -L# "https://bin.equinox.io/c/4VmDzA7iaHb/ngrok-stable-windows-amd64.zip" -o "%TMPDIR%\ngrok-amd64.zip"
)
if exist "%TMPDIR%\ngrok-amd64.zip" (
  echo. && echo ^> Extracting Ngrok ...
  %UNZIP% x "%TMPDIR%\ngrok-amd64.zip" -o"%TMPDIR%" -y > nul
  copy /Y "%TMPDIR%\ngrok.exe" "%ODIR%\utils\ngrok.exe" > nul
)

:: phpMyAdmin
if not exist "%TMPDIR%\phpmyadmin.zip" (
  echo. && echo ^> Downloading phpMyAdmin ...
  %CURL% -L# "https://phpmyadmin.net/downloads/phpMyAdmin-latest-english.zip" -o "%TMPDIR%\phpmyadmin.zip"
)
if exist "%TMPDIR%\phpmyadmin.zip" (
  echo. && echo ^> Extracting phpMyAdmin ...
  %UNZIP% x "%TMPDIR%\phpmyadmin.zip" -o"%TMPDIR%" -y > nul
  xcopy "%TMPDIR%\phpMyAdmin-%ver_phpmyadmin%-english" "%ODIR%\opt\phpmyadmin" /E /I /Y > nul
  copy /Y "%STUB%\opt\phpmyadmin\config.inc.php" "%ODIR%\opt\phpmyadmin\config.inc.php" > nul
)
