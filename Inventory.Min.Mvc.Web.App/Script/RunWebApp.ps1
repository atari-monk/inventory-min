$appPath = "C:\kmazanek.gmail.com\Apps\Inventory.Min.Mvc.Web.App"
$appFilePath = "C:\kmazanek.gmail.com\Apps\Inventory.Min.Mvc.Web.App\Inventory.Min.Mvc.Web.App.exe"
Start-Process -FilePath $appFilePath -WorkingDirectory $appPath -Verb RunAs