using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models.Response;

namespace ZeroChaos.TimesheetPOC.ViewModel
{
    public abstract class BaseViewModel: INotifyPropertyChanged
    {
        #region Properties
        private MasterDetailViewModel _MasterDetailViewModel;

        public MasterDetailViewModel MasterDetailViewModel
        {
            get { return _MasterDetailViewModel; }
            set { _MasterDetailViewModel = value; }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Methods
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
