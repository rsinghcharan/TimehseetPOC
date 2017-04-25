#region Namespaces
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Model.Candidate;
using ZeroChaos.TimesheetPOC.Model.Request.Common;
using ZeroChaos.TimesheetPOC.Models.Response;
#endregion

namespace ZeroChaos.TimesheetPOC.Model.Response.Candidate
{
	/// <summary>
	/// CandidatesCompareResponse class
	/// </summary>
	public class CandidatesCompareResponse : ResponseBase
	{
		public IList<CandidateDetails> Candidates { get; set; }
		public CandidatesCompareResponse()
		{
			Candidates = new ObservableCollection<CandidateDetails>();
		}
	}

	public class CandidateDetails
	{
		public int ReqCandId { get; set; }
		public int ReqSubId { get; set; }
		public String Name { get; set; }
		List<ActionDetails> actions = new List<ActionDetails>();
		public List<ActionDetails> Actions { get { return actions; } set { actions = value; } }
		public String SubmissionStatus { get; set; }
		public String SupplierName { get; set; }
		public CustomizedField FormerContractor { get; set; }
		public CustomizedField FormerFte { get; set; }
		public CustomizedField SuppplierBillRate { get; set; }
		public String TargetRateDifference { get; set; }
		public bool IsTargetRateDifferenceNegative { get; set; }
		List<PropertyAvailableDetails> competencies = new List<PropertyAvailableDetails>();
		public string CandidateCompantencies
		{
			get
			{
				return string.Join(",", Competencies.Select(X => X.ToString()).ToArray());
			}
		}
		List<PropertyAvailableDetails> certifications = new List<PropertyAvailableDetails>();
		public string CandidateCertifications
		{
			get
			{
				return string.Join(",", Certifications.Select(X => X.ToString()).ToArray());
			}
		}
		public List<PropertyAvailableDetails> Competencies { get { return competencies; } set { competencies = value; } }
		public List<PropertyAvailableDetails> Certifications { get { return certifications; } set { certifications = value; } }
		public CustomizedField Summary { get; set; }
		public bool IsSummaryLong { get; set; }
		public String SummaryShort { get; set; }
		public String Availability { get; set; }
		public String ActiveSubmits { get; set; }
		public String PreviousSubmits { get; set; }
		public String ProfileHyperlink { get; set; }
		public String RankingPercent { get; set; }
		public String AttachmentPath { get; set; }
		public String CandidateLocation { get; set; }
		public CustomizedField EmailAddress { get; set; }
		public int ReqSubStatusID { get; set; }
		public string ProfileImageName { get; set; }
		//ZMOB-3047
		public bool IsHire { get; set; }
		public bool IsOffer { get; set; }
	}
}
