<?php

require_once "Database.php";
error_reporting(E_ALL);
ini_set('display_errors', 1);

if(!file_exists("/var/www/api.grepolistools.com/LOCK"))
{

    mkdir("/var/www/api.grepolistools.com/LOCK");

    $getWorlds = sqlsrv_query($conn, "SELECT Id, Server_Name FROM World");
    $curDate = date("Y-m-d");

while($world = sqlsrv_fetch_array($getWorlds, SQLSRV_FETCH_ASSOC))
{
    $lastModifiedQ = sqlsrv_query($conn, "SELECT lastModified FROM World WHERE Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
    
    $checkMofidiedFile = file_get_contents("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/alliances.txt");
    $headers = $http_response_header;
    $lmHeaderDate = date('Y-m-d H:i:s', strtotime(substr($headers[5], -25)));

    while($lm = sqlsrv_fetch_array($lastModifiedQ, SQLSRV_FETCH_ASSOC))
    {
        if(new DateTime($lmHeaderDate) > $lm['lastModified'])
        {

            #region Deletes

                sqlsrv_query($conn, "DELETE FROM Alliance WHERE Date = '$curDate' AND World_Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Player WHERE Date = '$curDate' AND World_Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Town WHERE Date = '$curDate' AND World_Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Alliance_Att WHERE AllianceDate = '$curDate' AND AllianceWorld_Id = '$world[Id]' AND AllianceServer_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Alliance_Def WHERE AllianceDate = '$curDate' AND AllianceWorld_Id = '$world[Id]' AND AllianceServer_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Player_Att WHERE PlayerDate = '$curDate' AND PlayerWorld_Id = '$world[Id]' AND PlayerServer_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Player_Def WHERE PlayerDate = '$curDate' AND PlayerWorld_Id = '$world[Id]' AND PlayerServer_Name = '$world[Server_Name]'");
                sqlsrv_query($conn, "DELETE FROM Conquer WHERE World_Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
                if( ($errors = sqlsrv_errors() ) != null) {
                foreach( $errors as $error ) {
                echo "message: ".$error[ 'message']."\n";
                }
                }

            #endregion
            
                            #region Alliances

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/alliances.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliances.csv");
    exec("sed  -i '1i id,name,points,towns,members,rank\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliances.csv");
    exec("sed -i 's@+@ @g;s@%@\\x@g' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliances.csv | xargs -0 printf '%b'");
    
    sqlsrv_query($conn, "ALTER TABLE Alliance ADD CONSTRAINT DF_Alliance_Server_Name DEFAULT '$world[Server_Name]' FOR Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance ADD CONSTRAINT DF_Alliance_World DEFAULT '$world[Id]' FOR World_Id");
    sqlsrv_query($conn, "ALTER TABLE Alliance ADD CONSTRAINT DF_Alliance_Date DEFAULT '$curDate' FOR Date");
   
    sqlsrv_query($conn, "BULK INSERT Alliance FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliances.csv' WITH
        (
            FORMAT = 'CSV', 
            KEEPNULLS,
            FIRSTROW = 2,
            FORMATFILE = '/var/www/api.grepolistools.com/format/alliance.xml'
        );
    
    ");

    sqlsrv_query($conn, "ALTER TABLE Alliance DROP CONSTRAINT DF_Alliance_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance DROP CONSTRAINT DF_Alliance_World  ");
    sqlsrv_query($conn, "ALTER TABLE Alliance DROP CONSTRAINT DF_Alliance_Date  ");

    #endregion

    #region Players

    sqlsrv_query($conn, "ALTER TABLE Player ADD CONSTRAINT DF_Player_Date DEFAULT '$curDate' FOR Date");        
    sqlsrv_query($conn, "ALTER TABLE Player ADD CONSTRAINT DF_Player_Server_Name DEFAULT '$world[Server_Name]' FOR Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Player ADD CONSTRAINT DF_Player_World DEFAULT '$world[Id]' FOR World_Id");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/players.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_players.csv");
    exec("sed  -i '1i id,name,alliance_id,points,rank,towns\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_players.csv");
    exec("sed -i 's@+@ @g;s@%@\\x@g' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_players.csv | xargs -0 printf '%b'");
    sqlsrv_query($conn, "BULK INSERT Player FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_players.csv' WITH
        (
            FORMAT = 'CSV', 
            KEEPNULLS,
            FIRSTROW = 2,
            FORMATFILE = '/var/www/api.grepolistools.com/format/player.xml'
        );
    ");
    if( ($errors = sqlsrv_errors() ) != null) {
        foreach( $errors as $error ) {
        echo "message: ".$error[ 'message']."\n";
        }
        }
    sqlsrv_query($conn, "ALTER TABLE Player DROP CONSTRAINT DF_Player_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Player DROP CONSTRAINT DF_Player_World  ");
    sqlsrv_query($conn, "ALTER TABLE Player DROP CONSTRAINT DF_Player_Date  ");
    

    #endregion

    #region Towns

    sqlsrv_query($conn, "ALTER TABLE Town ADD CONSTRAINT DF_Town_Server_Name DEFAULT '$world[Server_Name]' FOR Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Town ADD CONSTRAINT DF_Town_World DEFAULT '$world[Id]' FOR World_Id");
    sqlsrv_query($conn, "ALTER TABLE Town ADD CONSTRAINT DF_Town_Date DEFAULT '$curDate' FOR Date");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/towns.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_towns.csv");
    exec("sed  -i '1i id,player_id,name,coord_x,coord_y,coord_island,points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_towns.csv");
    exec("sed -i 's@+@ @g;s@%@\\x@g' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_towns.csv | xargs -0 printf '%b'");
    sqlsrv_query($conn, "BULK INSERT Town FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_towns.csv' WITH
        (
            FORMAT = 'CSV',
            KEEPNULLS,
            FIRSTROW = 2,
            FORMATFILE = '/var/www/api.grepolistools.com/format/town.xml'
        );
    ");
    sqlsrv_query($conn, "ALTER TABLE Town DROP CONSTRAINT DF_Town_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Town DROP CONSTRAINT DF_Town_World  ");
    sqlsrv_query($conn, "ALTER TABLE Town DROP CONSTRAINT DF_Town_Date  ");

    #endregion

    #region AllianceAtt

    sqlsrv_query($conn, "ALTER TABLE Alliance_Att ADD CONSTRAINT DF_Alliance_Att_Server_Name DEFAULT '$world[Server_Name]' FOR AllianceServer_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att ADD CONSTRAINT DF_Alliance_Att_World DEFAULT '$world[Id]' FOR AllianceWorld_Id");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att ADD CONSTRAINT DF_Alliance_Att_Date DEFAULT '$curDate' FOR AllianceDate");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/alliance_kills_att.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_att.csv");
    exec("sed  -i '1i rank,alliance_id,points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_att.csv");
    sqlsrv_query($conn, "BULK INSERT Alliance_Att FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_att.csv' WITH
            (
                FORMAT = 'CSV',
                KEEPNULLS,
                FIRSTROW = 2,
                FORMATFILE = '/var/www/api.grepolistools.com/format/alliance_kills.xml'
            );
    ");


    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Att_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Att_World");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Att_Date");

    #endregion

    #region AllianceDef

    sqlsrv_query($conn, "ALTER TABLE Alliance_Def ADD CONSTRAINT DF_Alliance_Def_Server_Name DEFAULT '$world[Server_Name]' FOR AllianceServer_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Def ADD CONSTRAINT DF_Alliance_Def_World DEFAULT '$world[Id]' FOR AllianceWorld_Id");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Def ADD CONSTRAINT DF_Alliance_Def_Date DEFAULT '$curDate' FOR AllianceDate");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/alliance_kills_def.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_def.csv");
    exec("sed  -i '1i rank,alliance_id,points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_def.csv");
    sqlsrv_query($conn, "BULK INSERT Alliance_Def FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_alliance_def.csv' WITH
            (
                FORMAT = 'CSV',
                KEEPNULLS,
                FIRSTROW = 2,
                FORMATFILE = '/var/www/api.grepolistools.com/format/alliance_kills.xml'
            );
    ");

    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Def_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Def_World");
    sqlsrv_query($conn, "ALTER TABLE Alliance_Att DROP CONSTRAINT DF_Alliance_Def_Date");



    #endregion

    #region PlayerAtt

    sqlsrv_query($conn, "ALTER TABLE Player_Att ADD CONSTRAINT DF_Player_Att_Server_Name DEFAULT '$world[Server_Name]' FOR PlayerServer_Name");
    sqlsrv_query($conn, "ALTER TABLE Player_Att ADD CONSTRAINT DF_Player_Att_World DEFAULT '$world[Id]' FOR PlayerWorld_Id");
    sqlsrv_query($conn, "ALTER TABLE Player_Att ADD CONSTRAINT DF_Player_Att_Date DEFAULT '$curDate' FOR PlayerDate");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/player_kills_att.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_att.csv");
    exec("sed  -i '1i rank,player_id,points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_att.csv");
    sqlsrv_query($conn, "BULK INSERT player_Att FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_att.csv' WITH
            (
                FORMAT = 'CSV',
                KEEPNULLS,
                FIRSTROW = 2,
                FORMATFILE = '/var/www/api.grepolistools.com/format/player_kills.xml'
            );
    ");

    sqlsrv_query($conn, "ALTER TABLE Player_Att DROP CONSTRAINT DF_Player_Att_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Player_Att DROP CONSTRAINT DF_Player_Att_World");
    sqlsrv_query($conn, "ALTER TABLE Player_Att DROP CONSTRAINT DF_Player_Att_Date");

    #endregion    

    #region PlayerDef

    sqlsrv_query($conn, "ALTER TABLE Player_Def ADD CONSTRAINT DF_Player_Def_Server_Name DEFAULT '$world[Server_Name]' FOR PlayerServer_Name");
    sqlsrv_query($conn, "ALTER TABLE Player_Def ADD CONSTRAINT DF_Player_Def_World DEFAULT '$world[Id]' FOR PlayerWorld_Id");
    sqlsrv_query($conn, "ALTER TABLE Player_Def ADD CONSTRAINT DF_Player_Def_Date DEFAULT '$curDate' FOR PlayerDate");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/player_kills_def.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_def.csv");
    exec("sed  -i '1i rank,player_id,points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_def.csv");
    sqlsrv_query($conn, "BULK INSERT player_Def FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_player_def.csv' WITH
            (
                FORMAT = 'CSV',
                KEEPNULLS,
                FIRSTROW = 2,
                FORMATFILE = '/var/www/api.grepolistools.com/format/player_kills.xml'
            );
    ");

    sqlsrv_query($conn, "ALTER TABLE Player_Def DROP CONSTRAINT DF_Player_Def_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Player_Def DROP CONSTRAINT DF_Player_Def_World");
    sqlsrv_query($conn, "ALTER TABLE Player_Def DROP CONSTRAINT DF_Player_Def_Date");

    #endregion    

    // #region Conquers

    sqlsrv_query($conn, "ALTER TABLE Conquer ADD CONSTRAINT DF_Conquer_Server_Name DEFAULT '$world[Server_Name]' FOR Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Conquer ADD CONSTRAINT DF_Conquer_World DEFAULT '$world[Id]' FOR World_Id");

    copy("https://{$world['Server_Name']}{$world['Id']}.grepolis.com/data/conquers.txt", "/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_conquers.csv");
    exec("awk -i inplace -F ',' -v OFS=',' '{ $2 = strftime(\"%F %T\", $2) }; 1' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_conquers.csv");        
    exec("sed  -i '1i Town_id,Date,NewOwner,OldOwner,NewAlliance,OldAlliance,Points\n' /var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_conquers.csv");
    sqlsrv_query($conn, "BULK INSERT Conquer FROM '/var/www/api.grepolistools.com/data/{$world['Server_Name']}{$world['Id']}_conquers.csv' WITH
            (
                FORMAT = 'CSV',
                KEEPNULLS,
                FIRSTROW = 2,
                FORMATFILE = '/var/www/api.grepolistools.com/format/conquer.xml'
            );
            
    ");


    sqlsrv_query($conn, "ALTER TABLE Conquer DROP CONSTRAINT DF_Conquer_Server_Name");
    sqlsrv_query($conn, "ALTER TABLE Conquer DROP CONSTRAINT DF_Conquer_World");


    #endregion

    sqlsrv_query($conn, "UPDATE World SET lastModified = '$lmHeaderDate' WHERE Id = '$world[Id]' AND Server_Name = '$world[Server_Name]'");
        }
    }

}

rmdir("/var/www/api.grepolistools.com/LOCK");

}

?>