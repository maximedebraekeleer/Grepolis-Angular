<?php

require_once "Database.php";
error_reporting(E_ALL);
ini_set('display_errors', 1);

$getWorlds = $conn->query("SELECT server, id FROM world");
$curDate = date("Y-m-d");

while($world = $getWorlds->fetch_assoc())
{
    #region Alliances

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/alliances.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_alliances.txt");
    exec("sed  -i '1i id,name,points,towns,members,rank\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_alliances.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_alliances.txt' REPLACE INTO TABLE alliance COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (id,name,points,towns,members,rank) SET world_server = '$world[server]', world_id = $world[id], date = '$curDate'") or die(mysqli_error($conn));

    #endregion

    #region Players

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/players.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_players.txt");
    exec("sed  -i '1i id,name,alliance_id,points,rank,towns\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_players.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_players.txt' REPLACE INTO TABLE player COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (id,name,@alliance_id,points,rank,towns) SET alliance_id = nullif(@alliance_id,''), world_server = '$world[server]', world_id = $world[id], date = '$curDate'") or die(mysqli_error($conn));
    #endregion

    #region Towns

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/towns.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_towns.txt");
    exec("sed  -i '1i id,player_id,name,coord_x,coord_y,coord_island,points\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_towns.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_towns.txt' REPLACE INTO TABLE town COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (id,@player_id,name,coord_x,coord_y,coord_island,points) SET player_id = nullif(@player_id,''), world_server = '$world[server]', world_id = $world[id], date = '$curDate'") or die(mysqli_error($conn));

    #endRegion

    #region AllianceAtt

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/alliance_kills_att.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_att.txt");
    exec("sed  -i '1i rank,alliance_id,points,alliance_world_server,alliance_world_id,alliance_date\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_att.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_att.txt' REPLACE INTO TABLE allianceatt COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (rank,alliance_id,points,alliance_world_server,alliance_world_id,alliance_date) SET alliance_world_server = '$world[server]', alliance_world_id = $world[id], alliance_date = '$curDate'") or die(mysqli_error($conn));

    #endregion

    #region AllianceDef

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/alliance_kills_def.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_def.txt");
    exec("sed  -i '1i rank,alliance_id,points,alliance_world_server,alliance_world_id,alliance_date\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_def.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_alliance_def.txt' REPLACE INTO TABLE alliancedef COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (rank,alliance_id,points,alliance_world_server,alliance_world_id,alliance_date) SET player_world_server = '$world[server]', player_world_id = $world[id], player_date = '$curDate'") or die(mysqli_error($conn));

    #endregion



    #region Conquers

    copy("https://{$world['server']}{$world['id']}.grepolis.com/data/conquers.txt", "/var/lib/mysql-files/{$world['server']}{$world['id']}_conquers.txt");
    exec("sed  -i '1i town_id,time,new_player,old_player,new_alliance,old_alliance,points,world_server,world_id\n' /var/lib/mysql-files/{$world['server']}{$world['id']}_conquers.txt");
    $conn->query("LOAD DATA INFILE '/var/lib/mysql-files/{$world['server']}{$world['id']}_conquers.txt' REPLACE INTO TABLE conquers COLUMNS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES (town_id,time,new_player,@old_player,@new_alliance,@old_alliance,points,world_server,world_id) SET old_player = nullif(@old_player,''), new_alliance = nullif(@new_alliance,''), old_alliance = nullif(@old_alliance,''), world_server = '$world[server]', world_id = $world[id], date = '$curDate'") or die(mysqli_error($conn));


    #endRegion
}

?>