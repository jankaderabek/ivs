all:
	if not exist "nuget.exe" powershell -command "& { iwr https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe }"
	nuget.exe restore Calculator
	"C:\Program Files (x86)\MSBuild\14.0\bin\MSBuild.exe" Calculator\Calculator.sln /p:Configuration=Release
	
	
tests: all
	Calculator\packages\xunit.runner.console.2.2.0\tools\xunit.console 	Calculator\MathLibraryTests\bin\Release\MathLibraryTests.dll
	
	
run: all
	Calculator\Calculator\bin\Debug\Calculator.exe
	
	
clean:
	git clean -d -x -f