@echo off

REM cls
SET VERSION=%1
SET ENVIRONMENT=%2
SET MSGERROR=
SET /a EXIT_CODE=0

if not defined VERSION goto help
if not defined ENVIRONMENT SET ENVIRONMENT=Release
if %1==--help goto help
if %1==-h goto help

cd MediaInfo.Wrapper

dotnet build .\Arte.ITBIG.MediaInfo.csproj -c %ENVIRONMENT%
if %ERRORLEVEL% NEQ 0 SET MSGERROR=Build : error de compilation & goto error

dotnet pack .\Arte.ITBIG.MediaInfo.csproj -c %ENVIRONMENT%
if %ERRORLEVEL% NEQ 0 SET MSGERROR=Pack : error de packaging & goto error

dotnet nuget push "bin/%ENVIRONMENT%/Arte.ITBIG.MediaInfo.%VERSION%.nupkg" --source "github"
if %ERRORLEVEL% NEQ 0 SET MSGERROR=NuGet : error de publication & goto error

goto end

:error
echo. & echo.[Error %ERRORLEVEL%] %MSGERROR%
SET /a EXIT_CODE=1
goto end

:help
echo.
echo.Usage:  publish-version [OPTIONS] VERSION [ENVIRONMENT]
echo.
echo.Outils de publication d'une image sur le registry Github
echo.
echo.Options
echo.  -h, --help		affiche ce message
echo.
echo.Parametres
echo.  VERSION	Tag de version pour le registry Github (doit correspondre à la version du csproj)
echo.        		
echo.  ENVIRONMENT	Type d'environnement (debug ; release)
echo.        		Optionnel : valeur par défaut `release`
echo.

:end
cd ..
exit %EXIT_CODE%