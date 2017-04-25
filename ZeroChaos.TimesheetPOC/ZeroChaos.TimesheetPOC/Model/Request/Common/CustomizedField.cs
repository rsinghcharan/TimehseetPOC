using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Model.Request.Common
{
    /// <summary>
    /// CustomizedField class
    /// </summary>
    public class CustomizedField
    {
        public bool IsVisible { get; set; }
        public bool IsModify { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string Caption { get; set; }
        public string FieldValue { get; set; }
    }
}
