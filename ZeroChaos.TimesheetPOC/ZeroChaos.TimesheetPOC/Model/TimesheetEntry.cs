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
    /// TimesheetEntry class
    /// </summary>
    public class TimesheetEntry
    {
        public Nullable<int> TimesheetID { get; set; }
        public int DailyDetailID { get; set; }
        public int TimeDetailID { get; set; }
        public Nullable<int> PayCodeID { get; set; }
        private string _payCodeName = string.Empty;

        public string PayCodeName
        {
            get
            {
                return _payCodeName;
            }
            set { _payCodeName = value; }
        }

        public string PayRate { get; set; }
        public string BillRate { get; set; }
        public string PayRate_dv { get; set; }
        public string BillRate_dv { get; set; }
        public Nullable<int> TrackCodeID { get; set; }
        public string TrackCodeName { get; set; }
        public string TotalHours { get; set; }
        public string Units { get; set; }
        public string Units_dv { get; set; }
        public DateTime TimesheetEntryDate { get; set; }

        public string PayCodeDesc { get; set; }
        public string PayRateTotal { get; set; }
        public string BillTotal { get; set; }
        public string PayRateTotal_dv { get; set; }
        public string BillTotal_dv { get; set; }

        //Following properties are only applicable to Hourly With Details
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<UserDefinedFields> TimeDetailCustomFields { get; set; }
        public bool HasBreakTime { get; set; }
        public bool IsBreakItem { get; set; }
        public short? PayCodeRateTypeID { get; set; }
        public int Index { get; set; }
        public string TimesheetUnitsName { get; set; }
        public string DailyTrackcodePercentage { get; set; }

        // added by Shweta Kulshrestha as on 20.07.2015 against JIRA #2008
        public bool SickTimeAccrualTracking { get; set; }

        // ended by Shweta Kulshrestha as on 20.07.2015 against JIRA #2008
        public bool Workable { get; set; }

        public bool MealBreakTakenVisibility { get; set; }

        //Fix for ZMOB-2297 -- added workable to identify sick/lunch time to disable meal break toggle button
        public bool IsMealBreakToggleSwitchVisible { get; set; }

        public bool IsNewTimeEntry { get; set; }

        public bool IsUnitsDropdownVisibleForPeriodicDetail { get; set; }

        public TimesheetEntry()
        {
            TimeDetailCustomFields = new List<UserDefinedFields>();
        }
    }
}
