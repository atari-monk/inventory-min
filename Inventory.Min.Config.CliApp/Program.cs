using Config.Wrapper;
using DIHelper;
using Inventory.Min.Config.CliApp;
using Unity;

var unity = new UnityContainer()
    .AddExtension(new Diagnostic());
var serviceSuite = new Inventory.Min.Config.CliApp.ServiceSuite(unity);
serviceSuite.Register();
var suite = new SuiteConfig(
    unity.Resolve<IConfigReader>())
        .GetSuite(unity);
IBootstraper booter = new Bootstraper(suite);
booter.CreateApp();
booter.RunApp(args);