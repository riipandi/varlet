<?php
$cfg['blowfish_secret'] = '336939030c23d3f6db7fe1d7768040c6';
$i = 0; $i++;
$cfg['Servers'][$i]['auth_type']       = 'cookie';
$cfg['Servers'][$i]['host']            = '127.0.0.1';
$cfg['Servers'][$i]['connect_type']    = 'tcp';
$cfg['Servers'][$i]['AllowNoPassword'] = false;
$cfg['Servers'][$i]['hide_db']         = '^(information_schema|performance_schema|mysql|phpmyadmin|sys)$';
$cfg['MaxRows']                         = 100;
$cfg['SendErrorReports']                = 'never';
$cfg['ShowDatabasesNavigationAsTree']   = false;
