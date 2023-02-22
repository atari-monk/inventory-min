#this changes net version to net7.0 in csproj files of this sln
#find all csproj files recursive in sln directory
$paths = Get-ChildItem -Path ../ -include *.csproj -Recurse

$OnlyUpdateMatchingFrameworks = $true #can also be #false

$desiredTargetFramework = "net7.0"
$likeText = "net*"

#foreach found file, update the framework
foreach($pathobject in $paths)
{
    $path = $pathobject.fullname
    $doc = New-Object System.Xml.XmlDocument
    $doc.Load($path)
    $node = $doc.SelectSingleNode("//Project/PropertyGroup")
	$TargetFrameworkNode = $node.SelectSingleNode("TargetFramework")
	
	if (-not $TargetFrameworkNode) {
       write-host "Node does not exist!"
    }
    else {
        write-host "Node found!"

        write-host "value was" + $TargetFrameworkNode.InnerText

        if($OnlyUpdateMatchingFrameworks -eq $true)
        {
            write-host "Only matching nodes may be updated! Checking.."

            if($TargetFrameworkNode.InnerText -like $likeText)
            {
                write-host "Updating node!"

                $TargetFrameworkNode.InnerText = $desiredTargetFramework    
            }
        }
        else{
            write-host "Updating node!"

            $TargetFrameworkNode.InnerText = $desiredTargetFramework
        }        

        write-host "value is" + $TargetFrameworkNode.InnerText

        $doc.Save($pathobject)
    }    
}