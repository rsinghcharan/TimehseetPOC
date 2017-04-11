using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models.Response;

namespace ZeroChaos.TimesheetPOC
{
	public class TimesheetEndingDatesResponse : ResponseBase
	{
		public List<string> timesheetEntryDates { get; set; }
	}
	public class PayCodeInfoList
	{
		public int projID { get; set; }
		public int payCodeID { get; set; }
		public string payCodeName { get; set; }
		public string payRate { get; set; }
		public string billRate { get; set; }
		public string payCodeDesc { get; set; }
		public string timesheetUnits { get; set; }
		public bool isMealBreakToggleSwitchVisible { get; set; }
		public bool isUnitsDropdownVisibleForPeriodicDetail { get; set; }
		public int payCodeRateTypeID { get; set; }
	}
	public class TimesheetPayCodeResponse : ResponseBase
	{
		public List<PayCodeInfoList> payCodeInfoList { get; set; }
	}
}

