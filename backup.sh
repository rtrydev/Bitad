#!/bin/sh
name=bitad.sql
currentTime=$(date "+%Y-%m-%d_%H-%M-%S")
fileName=$name.$currentTime
docker-compose exec -u postgres db bash -c "cd /var/lib/postgresql && pg_dump Bitad > ${fileName}" && \
 docker cp db:/var/lib/postgresql/${fileName} ~/
