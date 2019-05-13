<?php

require_once("Database.php");
$twoWeeks = date("Y-m-d", strtotime("-2 Week"));
$OneWeek = date("Y-m-d", strtotime("-1 Week"));



$getWorlds = sqlsrv_query($conn, "SELECT Id, Server_Name, isOpen FROM World");

while($world = sqlsrv_fetch_array($getWorlds, SQLSRV_FETCH_ASSOC))
{
    if($world['isOpen'])
    {
        sqlsrv_query($conn, "DELETE FROM Town WHERE Date < '$OneWeek' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]'");
        sqlsrv_query($conn, "DELETE FROM Alliance WHERE Date < '$twoWeeks' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]' ");
        sqlsrv_query($conn, "DELETE FROM Player WHERE Date < '$twoWeeks' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]' ");
    }else
    {
        $dates = sqlsrv_query($conn, "SELECT DISTINCT(Date) FROM Player WHERE Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]' Order By Date Desc");
        $date = sqlsrv_fetch_array($dates, SQLSRV_FETCH_NUMERIC);
        $lastDate = date("Y-m-d", strtotime($date[0]->format("Y-m-d")));

        sqlsrv_query($conn, "DELETE FROM Town WHERE Date < '$lastDate' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]'");
        sqlsrv_query($conn, "DELETE FROM Alliance WHERE Date < '$lastDate' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]' ");
        sqlsrv_query($conn, "DELETE FROM Player WHERE Date < '$lastDate' AND Server_Name = '$world[Server_Name]' AND World_Id = '$world[Id]' ");
 
    }
}

?>