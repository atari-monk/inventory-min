$apiPath = "C:\kmazanek.gmail.com\Apps\Inventory.Min.Api"
$apiFilePath = "C:\kmazanek.gmail.com\Apps\Inventory.Min.Api\Inventory.Min.Api.exe"
Start-Process -FilePath $apiFilePath -WorkingDirectory $apiPath -Verb RunAs