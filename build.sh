#!/bin/sh
location=$1

cd $location
/usr/local/bin/docker-compose build && /usr/local/bin/docker-compose up -d