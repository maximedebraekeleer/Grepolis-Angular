<?php

error_reporting(E_ALL);
ini_set('display_errors', 1);

    $serverName = "localhost";
    $connectionOptions = array(
        "Database" => "grepolistools",
        "Uid" => "sa",
        "PWD" => "D93xd+m1998"
    );
    //Establishes the connection
    $conn = sqlsrv_connect($serverName, $connectionOptions);
?>