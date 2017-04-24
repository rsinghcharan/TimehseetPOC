using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetNotes
    {
        #region Private Member
        #endregion
      
        #region Property
        public List<ZcwNoteList> ItemSource
        {
            get { return lstView.ItemsSource as List<ZcwNoteList>; }
            set { lstView.ItemsSource = value; }
        }

        #endregion
        
        #region Constructor
        public TimesheetNotes()
        {
            InitializeComponent();
            //GetNotesList();
        }
        #endregion
        
        #region Public Method
        public void GetNotesList()
        {
            var BC = BindingContext as NotesTimesheetViewModel;
            BC.GetTimesheetNotesList();
        }
        #endregion

    }
}
