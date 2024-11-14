del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack mdmontesinos.Module.Issue4812.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

