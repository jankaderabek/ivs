MSBUILD = "C:\Program Files (x86)\MSBuild\14.0\bin\MSBuild.exe"
PARAMETERS = /p:Configuration=Release
COPY = copy /y

all: nuget
	$(MSBUILD) Calculator\Calculator.sln $(PARAMETERS) /t:Clean,Build

nuget:
	if not exist "nuget.exe" powershell -command "& { iwr https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe }"
	nuget.exe restore Calculator	
	
tests: nuget
	$(MSBUILD) Calculator\MathLib\MathLib.csproj $(PARAMETERS)
	$(MSBUILD) Calculator\MathLibraryTests\MathLibraryTests.csproj $(PARAMETERS)
	Calculator\packages\xunit.runner.console.2.2.0\tools\xunit.console 	Calculator\MathLibraryTests\bin\Release\MathLibraryTests.dll
	
run: all
	Calculator\Calculator\bin\Release\Calculator.exe
	
clean:
	git clean -d -x -f
	
doc: nuget
	$(MSBUILD) Calculator\Calculator.sln $(PARAMETERS) /p:DocumentationFile=Doc.xml /t:Clean,Build 
	if not exist "doc" mkdir "doc"
	$(COPY) Calculator\Calculator\bin\Release\Doc.xml doc\Calculator.xml
	$(COPY) Calculator\MathLib\bin\Release\Doc.xml doc\MathLib.xml
	$(COPY) Calculator\MathLibraryTests\bin\Release\Doc.xml doc\MathLibraryTests.xml
	
pack: doc
	if exist ..\..\xkader13_xzeman53_xjelin42 rmdir /s /q ..\..\xkader13_xzeman53_xjelin42
 	mkdir ..\..\xkader13_xzeman53_xjelin42
 	mkdir ..\..\xkader13_xzeman53_xjelin42\install
 	mkdir ..\..\xkader13_xzeman53_xjelin42\repo
 	mkdir ..\..\xkader13_xzeman53_xjelin42\doc
	xcopy /s /D /C /E /Q "install" "..\..\xkader13_xzeman53_xjelin42\install\"
	xcopy /s /D /C doc "..\..\xkader13_xzeman53_xjelin42\doc\"	
	git clean -d -x -f
	xcopy /s /D ..\. "..\..\xkader13_xzeman53_xjelin42\repo\"
	powershell -nologo -noprofile -command "& { Add-Type -A 'System.IO.Compression.FileSystem'; [IO.Compression.ZipFile]::CreateFromDirectory('..\..\xkader13_xzeman53_xjelin42', '..\..\xkader13_xzeman53_xjelin42.zip'); }"
	