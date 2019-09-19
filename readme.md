<p align="center"><img src="https://laravel.com/assets/img/components/logo-valet.svg"></p>

<p align="center">
<a href="https://travis-ci.org/riipandi/valet-windows"><img src="https://travis-ci.org/riipandi/valet-windows.svg" alt="Build Status"></a>
<a href="https://packagist.org/packages/riipandi/valet-windows"><img src="https://poser.pugx.org/riipandi/valet-windows/d/total.svg" alt="Total Downloads"></a>
<a href="https://packagist.org/packages/riipandi/valet-windows"><img src="https://poser.pugx.org/riipandi/valet-windows/v/stable.svg" alt="Latest Stable Version"></a>
<a href="https://packagist.org/packages/riipandi/valet-windows"><img src="https://poser.pugx.org/riipandi/valet-windows/license.svg" alt="License"></a>
</p>


## Introduction

This is another fork of Laravel Valet for Windows. Valet is a Laravel development environment. No Vagrant,
no `/etc/hosts` file. You can even share your sites publicly using local tunnels. Valet proxies all requests
on the `*.test` domain to point to sites installed on your local machine.

## Quick Start

Before installation, make sure that no other programs are binding to your local machine's port 80 and 443.
Also make sure to open your preferred terminal (CMD, Git Bash, PowerShell, etc.) as Administrator. If you
don't have PHP and composer installed, you can use [Varlet Core](//github.com/riipandi/varlet-core).

1. Install Valet with Composer via `composer global require riipandi/valet-windows-windows`
2. Run the `valet install` command. This command will configure and install Valet and register Valet's daemon.
3. If you're installing on Windows 10, you may need to manually configure Windows to use the Acrylic DNS proxy.

#### Configure DNS via command prompt

```cmd
# Set DNS configuration
netsh interface ipv4 add dnsservers "Ethernet" address=127.0.0.1 index=1
netsh interface ipv4 add dnsservers "Wi-Fi" address=127.0.0.1 index=1

# Revert DNS configuration
netsh interface ipv4 set dns "Ethernet" dhcp
netsh interface ipv4 set dns "Wi-Fi" dhcp
```

## Official Documentation

Documentation for Valet can be found on the [Laravel website](//laravel.com/docs/valet).

## License

Laravel is a trademark of Taylor Otwel. Laravel Valet is open-sourced software licensed under the
[MIT license](//opensource.org/licenses/MIT).

Please read the [license file](./license.txt) for more information.
