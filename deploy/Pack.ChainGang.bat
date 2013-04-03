@echo off
powershell -NoProfile -ExecutionPolicy unrestricted -Command "& {.\pack.ps1 -PackageName 'ChainGang'; exit $error.Count}"
pause