#!/bin/bash

mkdir -p ~/webapipublish

dotnet build -c Release

dotnet publish -c Release --no-build -o ~/webapipublish

dotnet run