using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC.ViewModel
{
    public class BaseViewModel
    {
        
        public MasterDetailViewModel MasterDetailViewModel
        {
            get { return Application.Current.MainPage.BindingContext as MasterDetailViewModel; }
        }
    }
}
