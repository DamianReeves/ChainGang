#Common NuGet/Archiving logic, not meant ot be executed directly.
 
$framework = '4.0'
 
task default -depends Pack
 
task Init {
    cls
}
 
task Clean -depends Init {
     
    if (Test-Path $ArchiveDir) {
        ri $ArchiveDir -Recurse
    }

    if (Test-Path $NupackDir) {
        ri $NupackDir -Recurse
    }
     
    ri ChainGang*.nupkg
    ri ChainGang*.zip -ea SilentlyContinue
}
 
task Build -depends Init,Clean {
    exec { msbuild $SolutionFile }
}
 
#This function can be overriden to add additional logic to the archive process.
function OnArchiving {
}
 
task Pack -depends Build {
    if (!(Test-Path $NupackDir)) {
        mkdir $NupackDir
    }

    exec { ..\tools\nuget pack "$ProjectPath" -OutputDirectory $NupackDir }
}
 
task Publish -depends Pack {        
    $PackageName = gci  "$NupackDir\$NuGetPackageName.*.nupkg"
    exec { ..\tools\nuget push $PackageName }
}