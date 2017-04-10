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
    /// Login Request class
    /// </summary>
    public class LoginRequest
    {
        public string emailAddress { get; set; }
        public string password { get; set; }

    }

}
