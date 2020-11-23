using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using Forms = System.Windows.Forms;
using Microsoft.Win32;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Creation = Autodesk.Revit.Creation;
using System.Collections.ObjectModel;

namespace REVIT_TEST.ViewModels
{
    public class ViewModel : NotifyPropertyChanged
    {
        public Command CommandProp { get; set; }
             
        public ViewModel()
        {
            CommandProp = new Command (Commands, CanExecute);
        }

        public void Commands(object wnd)
        {

        }

        public bool CanExecute(object wnd)
        {
            return true;
        }
    }
}
