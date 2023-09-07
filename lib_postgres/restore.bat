@echo off 
SET PGPASSWORD=%1
@echo on
%3\pg_restore" -h localhost -p 5432 -d lib -U postgres "%2"
@echo off 
SET PGPASSWORD=""
@echo on
pause
