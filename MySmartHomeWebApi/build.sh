#!/bin/bash

rm -rf app/
mkdir -p app/
cd /app
git clone https://github.com/as112/MySmartHome.git

cd MySmartHome/MySmartHomeWebApi/

mkdir -p ~/webapipublish

dotnet build -c Release

dotnet publish -c Release --no-build -o ~/webapipublish

dotnet run