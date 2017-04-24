using System;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models.Request;

namespace ZeroChaos.TimesheetPOC
{
	public class TimesheetEndingDatesRequest : RequestBase
	{

		public string timesheetEndingDate { get; set; }
		public int projectID { get; set; }
	}
	public class TimesheetPayCodeRequest : TimesheetEndingDatesRequest
	{
		public int timesheetTypeID { get; set; }
	}
}

