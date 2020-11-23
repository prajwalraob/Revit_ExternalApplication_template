using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Creation = Autodesk.Revit.Creation;

namespace REVIT_TEST
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExternalProgram : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("Prajwal's Apps");
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Prajwal's Apps", "New Tools");
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dllPath = Path.Combine(appData, @"Autodesk\REVIT\Addins\2018\REVIT_TEST.dll");
            PushButtonData pushButton1 = new PushButtonData("Test1", "IP1", dllPath, "REVIT_TEST.InternalProgram");
            pushButton1.AvailabilityClassName = "REVIT_TEST.AvailabilityControl";
            ribbonPanel.AddItem(pushButton1);
            return Result.Succeeded;
        }
    }

    public class AvailabilityControl : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            return true;
        }
    }
}
