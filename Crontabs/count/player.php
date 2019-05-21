<?php

require_once "Database.php";
error_reporting(E_ALL);
ini_set('display_errors', 1);

$server = "nl";
$world = 64;
$curDate = date("Y-m-d");

if(isset($world))
{
    $q = sqlsrv_query($conn, "SELECT COUNT(DISTINCT(name)) FROM PLAYER WHERE Date = '$curDate' AND World_Id = '$world' AND Server_Name = '$server'");
    while($count = sqlsrv_fetch_array($q, SQLSRV_FETCH_NUMERIC))
    {
        echo $count[0];
    }
}else {
    $q = sqlsrv_query($conn, "SELECT COUNT(DISTINCT(name)) FROM PLAYER WHERE Date = '$curDate' AND Server_Name = '$server'");
    while($count = sqlsrv_fetch_array($q, SQLSRV_FETCH_NUMERIC))
    {
        echo $count[0];
    }
}


?>