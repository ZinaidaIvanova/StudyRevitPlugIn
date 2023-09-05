using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace MyRevitPlugin
{
    public class RevitPlugin : IExternalApplication
    {
        private const string TabName = "MyPlagin";
        private const string RibbonName = "Контрольная панель плагин";

        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        private void AddRibbonPanel(UIControlledApplication application)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");
            RibbonPanel viewPanel = application.CreateRibbonPanel(TabName, RibbonName);
            

        }
    }
}
