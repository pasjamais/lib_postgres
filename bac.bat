set _my_datetime=%date%_%time%
set _my_datetime=%_my_datetime: =_%
set _my_datetime=%_my_datetime::=%
set _my_datetime=%_my_datetime:/=_%
set _my_datetime=%_my_datetime:.=_%
set _my_datetime=%_my_datetime:,=_%
SET PGPASSWORD=%1
"C:\Program Files\PostgreSQL\14\bin\pg_dump.exe" -h localhost -p 5432 -U postgres -F c -b -v -f ".\%2\lib.backup" lib
ren .\%2\lib.backup lib_%_my_datetime%.sql
pause
explorer .\%2\