<?php

require_once("grepolistools.com/application/cronjobs/Database.php");
$deleteTime = date("Y-m-d", strtotime("-1 Week"));

$worlds = $conn->query("SELECT id, server, closingDate FROM world");
while($world = $worlds->fetch_assoc())
{
    if(strtotime($world["closingDate"]) < strtotime("now"))
    {
        $conn->query("DELETE from player WHERE date < '$world[closingDate]'");
        $conn->query("DELETE from alliance WHERE date < '$world[closingDate]'");
        $conn->query("DELETE from town WHERE date < '$world[closingDate]'");
    }else 
    {
        $conn->query("DELETE from player WHERE date < '$deleteTime'");
        $conn->query("DELETE from alliance WHERE date < '$deleteTime'");
        $conn->query("DELETE from town WHERE date < '$deleteTime'");
    }
}

?>