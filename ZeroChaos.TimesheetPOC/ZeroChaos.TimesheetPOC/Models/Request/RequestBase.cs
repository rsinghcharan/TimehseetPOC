#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models.Request
{
    /// <summary>
    /// RequestBase class
    /// </summary>
    public class RequestBase
    {
        public UserInfo loggedonUser { get; set; }
    }
}
