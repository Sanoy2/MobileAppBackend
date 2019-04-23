#!/bin/bash

date

echo Publishing is starting
sudo dotnet publish -r linux-arm # publish for Raspberry
wait
echo "Build done"

wait

rsync -ruv /home/krzysztof/dotnet/MobileAppBackend/MobileBackend/bin/Debug/netcoreapp2.1/linux-arm/publish/* pi@192.168.0.241:/home/pi/dotnet/Mobile

echo "Copying done"