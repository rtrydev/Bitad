#!/bin/sh
location=$1
name=bitad.sql

mv ./.env .env.old
mv ./.env.new .env

cd $location
mv .env .env.old
mv .env.new .env
/bin/bash ./deploy.sh