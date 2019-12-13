<p align="center"><img src="./source/Resources/logoWide.png" height="128px"></p>
<p align="center">
  <a href="https://github.com/riipandi/varlet/releases">
    <img alt="GitHub release (latest SemVer)" src="https://img.shields.io/github/v/release/riipandi/varlet?style=flat-square&sort=semver">
  </a>
  <img alt="GitHub All Releases" src="https://img.shields.io/github/downloads/riipandi/varlet/total?style=flat-square">
  <a href="https://choosealicense.com/licenses/apache-2.0/" target="_blank">
    <img alt="Apache License" src="https://img.shields.io/badge/License-Apache%202.0-blue.svg?style=flat-square">
  </a>
  <a href="https://github.com/riipandi/varlet/commits/">
    <img alt="GitHub commit activity" src="https://img.shields.io/github/commit-activity/m/riipandi/varlet?label=activity&style=flat-square">
  </a>
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/riipandi/varlet?style=flat-square">
</p>

## Introduction

Varlet is a a web development environment for minimalists, inspired from [Laravel Valet](https://laravel.com/docs/valet)
and [Laragon](https://laragon.org). Varlet only includes PHP, Composer, and HTTP web server. If you want to use databases
like PostgreSQL, MariaDB/MySQL, Redis, you need to install them separately.

Varlet is made for you, the developers who like to work in the terminal, like me!

## What's in the box?

- Multiple PHP v7.x
- Apache HTTPD
- Composer
- xDebug
- PHP Redis
- ImageMagick
- ionCube loader
- Phalcon PHP extension
- Mailhog + mhsendmail
- Adminer db manager
- Automatic https

## Where is the databases?

The Varlet package does not include database engines such as MariaDB / MySQL, PostgreSQL, or even Redis. You are free
to install any database distribution as you wish. Or you can use our simplified database distribution at
[Varlet Addons](https://github.com/riipandi/varlet-addons).

## Quick Start

To install Varlet you need [dotNet Framework](https://dotnet.microsoft.com/download/dotnet-framework) >= 4.5.2,
then download [latest release](https://github.com/riipandi/varlet/releases) and run installation file.

Varlet doesn't have `park` command like Laravel Valet does, your project files can stored at:
`installation_path\www`.

Or, you can use the `varlet link` command and place your project files in any directory you want.

## Building Packages

I'm using Rider from JetBrains, but you can use [Visual Studio Build Tools](https://visualstudio.microsoft.com/downloads/#vstool-2019-family) too.

In summary, to compile without the need to have Visual Studio or Rider installed:

1. Download [JetBrains MSBuild](https://jb.gg/msbuild), extract to `C:\SDK\JetMSBuild`
2. Download and install Microsoft [.NET Framework Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework) 4.5.2 or later
3. Download and install [Inno Setup](http://www.jrsoftware.org/isdl.php) (for creating the installer file)
4. Finally, run `setup.bat` and enjoy a cup of coffee.

Or, using Microsoft Visual Studio Build Tools:

1. Download this file: <https://www.visualstudio.com/downloads/#build-tools-for-visual-studio-2019>
2. Run: `vs_buildtools.exe --add Microsoft.VisualStudio.Workload.MSBuildTools --quiet`
3. For more detail, read more at [StackOverflow](https://stackoverflow.com/questions/42696948/how-can-i-install-the-vs2017-version-of-msbuild-on-a-build-server-without-instal).

<!-- ## Varlet Commands

| Command                      | Description
| :--------------------------- | :----------
| `varlet link`                  | Create virtualhost and serving the site
| `varlet unlink`                | Remove virtualhost
| `varlet forget`                | Remove both of virtualhost http and https
| `varlet start`                 | Start Httpd service
| `varlet stop`                  | Stop Httpd service
| `varlet restart`               | Restart Httpd service
| `varlet status`                | View site link status
| `varlet service-status`        | View services status
| `varlet switch-php _version_`  | Switch PHP version `7.4/7.3/7.2` -->

## License

Varlet is free software: you can distribute it and or modify it according to the license provided.
Varlet is a compilation of free software, it's free of charge and it's free to copy under the terms
of the [Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/). Please check every
single licence of the contained products to get an overview of what is, and what isn't, allowed.
In the case of commercial use please take a look at the product licences (_especially MySQL_),
from the my point of view commercial use is also free.

Read the [licence file](./license.txt) file for the full Varlet license text.
