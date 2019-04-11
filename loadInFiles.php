<?php

require_once "Database.php";
error_reporting(E_ALL);
ini_set('display_errors', 1);

$getWorlds = $conn->query("SELECT server, id FROM world");
$curDate = date("Y-m-d");

echo date("h:i:sa");

while($world = $getWorlds->fetch_assoc())
{
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_alliances.txt");
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_players.txt");
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_towns.txt");
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_alliance_att.txt");
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_alliance_def.txt");
    mkdir("/var/lib/mysql/{$world['server']}{$world['id']}_conquers.txt");
}

echo date("h:i:sa");

?>