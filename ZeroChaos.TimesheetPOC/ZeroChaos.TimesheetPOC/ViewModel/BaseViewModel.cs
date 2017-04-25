using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace ZeroChaos.TimesheetPOC.ViewModel
{
    public abstract class BaseViewModel : ViewModelBase
    {
        #region Properties
        private MasterDetailViewModel _MasterDetailViewModel;

        public MasterDetailViewModel MasterDetailViewModel
        {
            get { return _MasterDetailViewModel; }
            set { _MasterDetailViewModel = value; }
        }
        #endregion
 }
}
