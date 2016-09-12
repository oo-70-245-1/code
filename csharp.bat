@echo off
:: Nathan Adams
:: 8/13/2014
:: 70-245 Object Oriented Design

:: This script is designed to invoke the C# compiler assuming that they don't have VS installed
:: Microsoft bundles csc.exe with the .Net Framework itself which lives under:
:: C:\Windows\Microsoft.NET\Framework

:: Note - .Net 3.0 does not seem to come packages with .Net compilers

:: This script will go down and attempt to find one - the assumption is that every system has .Net installed.

if exist C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe (
	echo Compiling with .Net 4.0
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe %*
	goto :end
)

if exist C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe (
	echo Compiling with .Net 3.5
	C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe %*
	goto :end
)

if exist C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe (
	echo Compiling with .Net 2.0
	C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe %*
	goto :end
)

:end

if exist %CD%\%~n1.exe (
	%CD%\%~n1.exe
)
pause