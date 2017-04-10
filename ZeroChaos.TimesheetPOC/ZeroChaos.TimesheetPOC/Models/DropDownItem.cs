#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    /// <summary>
    /// DropDownItem class
    /// </summary>
    public class DropDownItem
    {
        public DropDownItem()
        {
        }
        public DropDownItem(string name, string value, int? ShareWithID = null)
        {
            this.Name = name;
            this.Value = value;
            this.ShareWithID = ShareWithID;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ShareWithID { get; set; }
    }
}
