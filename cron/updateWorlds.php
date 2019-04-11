<?php

    require_once "simple_html_dom.php";
    require_once "Database.php";
    error_reporting(E_ALL);
    ini_set('display_errors', 1);
    #region CHECK FOR NEW WORLDS/UPDATE EXISTING ONES

    $isWarriorsWorldsFound = false;

    $servers = $conn->query("SELECT * FROM server");

    while ($server = $servers->fetch_assoc())
    {
    
        $html = file_get_html("https://". $server['id'] ."0.grepolis.com/start/hall_of_fame", false, null, 0);

        foreach($html->find('script') as $element) 
           {
    
               if(strpos($element, "warriors_worlds"))
               {
    
                $isWarriorsWorldsFound = true;
    
                $lastIndex = strpos(substr($element, strpos($element, "warriors_worlds")), ']')-19;
                $array = substr(substr($element, strpos($element, "warriors_worlds")+19), 0, $lastIndex);
    
                $eArray = explode("},", $array);
                $worlds = array();
    
                foreach ($eArray as $world) 
                {
                    if(substr($world, -1) == '}')
                    {
                        array_push($worlds, json_decode($world, TRUE));
                    }else {
                        array_push($worlds, json_decode($world . "}", TRUE));
                    }
                }
                
                    foreach ($worlds as $world) 
                    {
                        
                        $server = substr($world['id'], 0, 2);
                        $id = substr($world['id'], 2);
                        $isDomination = 0;
                        if($world['is_domination'])
                        {
                            $isDomination = 1;
                        }
                        $isOpen = 1;
                        if($world['closed'])
                        {
                            $isOpen = 0;
                        }

                        if($isOpen)
                        {
                            $conn->query("INSERT INTO world (id, name, isOpen, server, isDomination) VALUES ($id, '$world[name]', $isOpen , '$server', $isDomination) ON DUPLICATE KEY UPDATE id = $id");
                        }else{
                            $q = $conn->query("SELECT closingDate FROM world WHERE id = $id AND server = '$server'");
                            while($world = $q->fetch_assoc())
                            {
                                if(!isset($world["closingDate"]))
                                {
                                    $closingDate = date('Y/m/d', strtotime('+1 month'));
                                    $conn->query("UPDATE world SET isOpen = $isOpen WHERE id = $id AND server = '$server'");
                                    $conn->query("INSERT INTO world(closingDate) VALUES ('$closingDate')");
                                }
                            }
                        }
                        
                        

                    }
                
               }
                        
           }
    
           //ERROR HANDLING IN CASE NO WARRIOR WORLDS VAR WAS FOUND
           if(!$isWarriorsWorldsFound)
           {
               echo "No Warriors_Worlds variable was found for server " . $server['id'] . ".";
           }

    }

    #endregion


?>
