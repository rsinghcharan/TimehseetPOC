#region namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    /// <summary>
    /// UserInfo class
    /// </summary>
    public class UserInfo
    {
        public int userID { get; set; }
        public int userType { get; set; }
        public string userName { get; set; }
        public int userPreferredLanguageID { get; set; }
        public int userPreferredCNLanguageID { get; set; }
        public string userPreferredLanguageName { get; set; }
        public int userPreferredTimeZoneID { get; set; }
        public string userPreferredTimeZoneName { get; set; }
        public string userCulture { get; set; }
        public int zCWUserID { get; set; }
        public Guid userGUID { get; set; }
    }
}
