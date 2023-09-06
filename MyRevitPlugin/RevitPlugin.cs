using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace MyRevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RevitPlugin : IExternalApplication
    {
        private const string TabName = "MyPlagin";
        private const string RibbonName = "Контрольная панель плагин";

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            return Result.Succeeded;
        }

        private void AddRibbonPanel(UIControlledApplication application)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");
            RibbonPanel viewPanel = application.CreateRibbonPanel(TabName, RibbonName);

            var helloWorldName = typeof(HelloWorld).FullName;
            var ViewPanelName = typeof(ViewPanelCommand).FullName;

            var helloWorldButton = new PushButtonData(
               "HelloWorld",
               "Hello World",
               thisAssemblyPath,
               helloWorldName)
            {
                //Image = showImg,
                ToolTip = "Say hello to the entire world.",
               // LargeImage = showImg
            };

            var ViewPanelButton = new PushButtonData(
                "ViewPanel",
                "Показать дерево",
                thisAssemblyPath,
                ViewPanelName)
            {
               // Image = hideImg,
                ToolTip = "Показать дерево",
                //LargeImage = hideImg
            };
            // var
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class HelloWorld : IExternalCommand
    {
        // The main Execute method (inherited from IExternalCommand) must be public
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            TaskDialog.Show("Revit", "Hello World");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ViewPanelCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }
    }
}
