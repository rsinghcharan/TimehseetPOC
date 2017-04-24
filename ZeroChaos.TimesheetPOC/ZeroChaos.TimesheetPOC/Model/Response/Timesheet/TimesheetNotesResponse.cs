using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models.Response;

namespace ZeroChaos.TimesheetPOC.Models.Response.Timesheet
{

	public class NoteType
	{
		public bool isVisible { get; set; }
		public bool isModify { get; set; }
		public bool isRequired { get; set; }
		public string caption { get; set; }
		public string fieldValue { get; set; }
	}
	public class ZcwNoteList
	{
		public string note { get; set; }
		public NoteType noteType { get; set; }
		public string emails { get; set; }
		public string createdBy { get; set; }
		public string createdOn { get; set; }
		public string objectStatus { get; set; }
		public int notesID { get; set; }
		public bool serviceLevelAgreement { get; set; }
	}
	public class TimesheetNotesResponse : ResponseBase
	{
		public bool isNotesVisible { get; set; }
		public bool isNoteTypeVisible { get; set; }							
		public bool isEmailToVisible { get; set; }
		public bool isCreatedByVisible { get; set; }
		public bool isCreatedOnVisible { get; set; }
		public bool isObjectStatusNameVisible { get; set; }
		public List<ZcwNoteList> zcwNoteList { get; set; }
		public int recordCount { get; set; }
	}
}

