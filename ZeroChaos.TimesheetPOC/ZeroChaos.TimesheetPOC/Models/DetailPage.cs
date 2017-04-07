#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    /// <summary>
    /// DetailPage class
    /// </summary>
    public class DetailPage : ContentPage
    {
        #region Constructors
        public DetailPage()
        {
            SideContentVisible = false;
        }
        #endregion

        #region Properties
        public bool SideContentVisible { get; set; }
        #endregion
    }
}
