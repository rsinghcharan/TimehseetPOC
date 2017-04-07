#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Models.Response;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    /// <summary>
    /// ZCMobileSystemConfiguration class
    /// </summary>
    public class ZCMobileSystemConfiguration
    {
        public ZCMobileSystemConfiguration()
        {
            CurrentUserInfo = new LoginResponse();
            LoggedonUser = new UserInfo();
        }
        public string SelectedDataCenter { get; set; }
        public LoginResponse CurrentUserInfo { get; set; }
        public UserInfo LoggedonUser { get; set; }
        public bool RememberUser { get; set; }
        public string RememberedUser { get; set; }
        public bool SideContentVisibility { get; set; }
    }
}
