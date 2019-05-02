<?php

require_once("Database.php");
$OneMonth = date("Y-m-d", strtotime("-1 Month"));
$OneWeek = date("Y-m-d", strtotime("-1 Week"));

sqlsrv_query($conn, "DELETE FROM Town WHERE Date < '$OneWeek' ");
sqlsrv_query($conn, "DELETE FROM Alliance WHERE Date < '$OneMonth' ");
sqlsrv_query($conn, "DELETE FROM Player WHERE Date < '$OneMonth' ");

?>