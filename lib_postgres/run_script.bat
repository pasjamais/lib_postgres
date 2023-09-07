@echo off 
SET PGPASSWORD=%1
@echo on
%3 -h localhost -p 5432 -d lib -U postgres -f "%2"
@echo off 
SET PGPASSWORD=""
@echo on
pause

