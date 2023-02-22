#this generates local nugets from my libs in this sln
$path = "C:\atari-monk\app-nugets";

#libs independent from my libs 
$libs0 = '';
#libs dependent on libs0
$libs1 = '';
#libs dependent on libs0 and/or libs1
$libs2 = '';

$libs = $libs0 + $libs1 + $libs2;

Set-Location ..

foreach ($lib in $libs) {
  Set-Location $lib

  dotnet pack -c Release -o $path
  
  Set-Location ..
}