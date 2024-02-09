rem simple backup bat file
rem 1 arg: password, 2 arg: directory for backup, 3 arg: PostgreSQL version number
rem  it's no verbose
set _my_datetime=%date%_%time%
set _my_datetime=%_my_datetime: =_%
set _my_datetime=%_my_datetime::=%
set _my_datetime=%_my_datetime:/=_%
set _my_datetime=%_my_datetime:.=_%
set _my_datetime=%_my_datetime:,=_%
@echo off
SET PGPASSWORD=%1
@echo on
"C:\Program Files\PostgreSQL\%3\bin\pg_dump.exe" -h localhost -p 5432 -U postgres -F plain --schema-only -f "%2\skeleton.backup" lib
ren %2\skeleton.backup skeleton_%_my_datetime%.sql
@echo off
SET PGPASSWORD=%1
@echo on
pause
explorer %2\