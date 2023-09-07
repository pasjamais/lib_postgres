@echo off
set _my_datetime=%date%_%time%
set _my_datetime=%_my_datetime: =_%
set _my_datetime=%_my_datetime::=%
set _my_datetime=%_my_datetime:/=_%
set _my_datetime=%_my_datetime:.=_%
set _my_datetime=%_my_datetime:,=_%
SET PGPASSWORD=%1
@echo on
%3 -h localhost -p 5432 -U postgres -F c -b -v -f ".\%2\lib.backup" lib
@echo off
ren .\%2\lib.backup lib_%_my_datetime%.sql
SET PGPASSWORD=""
@echo on
pause
explorer .\%2\