echo "****** Them cac file thay doi******"
git add *
echo ****** Commit len master

@echo off
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
echo ****** Ngày %mydate% %mytime%
git commit -m somechange
echo ******PULL ve origin*****
git pull
echo ******Push len master******
git push