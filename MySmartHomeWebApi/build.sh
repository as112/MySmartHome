#!/bin/bash

mkdir -p webapipublish


dotnet publish MySmartHomeWebAPI.csproj -c Release -o webapipublish

dotnet run --project MySmartHomeWebAPI.csproj