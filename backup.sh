#!/bin/sh
location=$1
name=bitad.sql
currentTime=$(date "+%Y-%m-%d_%H-%M-%S")
fileName=$name.$currentTime

cd $location
/usr/local/bin/docker-compose exec -T -u postgres db bash -c "cd /var/lib/postgresql && pg_dump Bitad > ${fileName}" && \
 docker cp db:/var/lib/postgresql/${fileName} $location