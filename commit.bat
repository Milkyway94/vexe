echo "Add to master"
git add *
echo Commit some change on 

@echo off
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
echo %mydate%_%mytime%
git commit -m somechange
echo PULL to origin
git pull
echo Push to master
git push