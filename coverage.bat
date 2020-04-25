rem ===========================================================================
rem coverage.bat
rem ===========================================================================

rem ===========================================================================
rem Tool path

set MSTEST="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
set OPENCOVER=%USERPROFILE%"\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe"
set REPORTGEN=%USERPROFILE%"\.nuget\packages\reportgenerator\4.5.2\tools\net47\ReportGenerator.exe"

rem ===========================================================================
rem target informations

rem test target
set TEST_PROJECT=PropertyListViewTests
set TEST_TARGET=%TEST_PROJECT%.dll

rem Open Cover parameters
set TARGET=%MSTEST%
set TARGET_DIR=%TEST_PROJECT%"\bin\Debug"
set TARGET_ARG=%TEST_TARGET%
set OPENCOVER_RESULT="coverage.xml"

rem output ReportGenerator result directory
set OUTPUT_DIR="Coverage"

rem target filter
set FILTERS="+[*]* -[*]*.Properties.* -[*]*.Tests.* -[*]AutoGeneratedProgram"

rem ===========================================================================
%OPENCOVER% -register:user -target:%TARGET% -targetargs:%TARGET_ARG% -targetdir:%TARGET_DIR% -filter:%FILTERS% -output:%OPENCOVER_RESULT%
%REPORTGEN% -reports:%OPENCOVER_RESULT% -targetdir:%OUTPUT_DIR%

%OUTPUT_DIR%\index.htm
