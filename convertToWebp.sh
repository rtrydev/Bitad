#!/bin/bash
for file in $1/*
do
  filesize=$(ls -la $file | awk '{print  $5}')
    cwebp -q 60 $file -o $file.webp
done