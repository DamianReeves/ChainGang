properties {
    $BaseDir = Resolve-Path "..\"
    $SolutionFile = "$BaseDir\ChainGang.sln"
    $ChainGangOutput = "$BaseDir\ChainGang\bin\Debug"
    $ProjectPath = "$BaseDir\ChainGang\ChainGang.csproj" 
    $ArchiveDir = "$BaseDir\deploy\Archive"
    $NupackDir = "$BaseDir\deploy\packages"

    $NuGetPackageName = "ChainGang"    
 
    $ZipFiles =  @("$BaseDir\README.md",
        "$ChainGangOutput\ChainGang.dll"
        )
    $ZipName = "ChainGang.zip"
}
 
. .\common.ps1
 
function OnArchiving {
}