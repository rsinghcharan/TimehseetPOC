using System;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
	/// <summary>
	/// TimesheetNotesRequest class containes the required necessary properties for getting TimesheetNotes Data.
	/// </summary>
	public class TimesheetNotesRequest : ContentPage
	{
		public int Offset { get; set; }
		public int Pagesize { get; set; }
		public int objectID { get; set; }
		public int clientID { get; set; }
		public int PKID { get; set; }
		/// <summary>
		/// loggedonUser class contains the list of objects required to create the loggedonUser and in Which we will store the current user details.
		/// </summary>
		/// <value>The loggedon user.</value>
		public UserInfo loggedonUser { get; set; }
	}
}

