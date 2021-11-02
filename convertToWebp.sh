#!/bin/bash
for file in $1/*
do
  filesize=$(ls -la $file | awk '{print  $5}')
    cwebp -q 60 $file -o $file.webp
done

# Install 
# on CentOs sudo yum install libwebp-tools
# or on Linux sudo apt-get install webp