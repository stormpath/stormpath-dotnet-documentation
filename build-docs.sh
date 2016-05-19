#!/bin/bash

cd docs;
make html FRAMEWORK=aspnetcore
make html FRAMEWORK=aspnet
#make html FRAMEWORK=nancy
