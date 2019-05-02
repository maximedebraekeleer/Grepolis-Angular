awk -i inplace -F ',' -v OFS=',' '{ $2 = strftime("%F %T", $2) }; 1' '/var/www/api.grepolistools.com/data/[a-z]{2}[0-9]{2,3}_conquers.csv'
