#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Model.Request.Candidate;
using ZeroChaos.TimesheetPOC.Model.Response.Candidate;
using ZeroChaos.TimesheetPOC.Services;
#endregion

namespace ZeroChaos.TimesheetPOC.ViewModel.CandidateCompare
{
    /// <summary>
    /// CandidatesCompareViewModel class
    /// </summary>
    public class CandidatesCompareViewModel : BaseViewModel
    {
        #region Properties
        private CandidatesCompareResponse candidateCompareData;
        public CandidatesCompareResponse CandidateCompareData
        {
            get
            {
                return candidateCompareData;
            }
            set
            {
                candidateCompareData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public CandidatesCompareViewModel()
        {
            
        }
        #endregion

        #region Public Methods
        public async void GetCandidatesCompareData(Action<CandidatesCompareResponse> Callback)
        {
            IServiceCaller service = new ServiceCaller();
            var request = this.GetCandidatesCompareRequest();
            await service.CallHostService<CandidatesCompareRequest, CandidatesCompareResponse>(request, "GetCandidatesCompareRequest", (res) =>
            {
                Callback(res);
            });
        }
        #endregion

        #region Private Methods
        private CandidatesCompareRequest GetCandidatesCompareRequest()
        {
            return new CandidatesCompareRequest
            {
                reqID = 489999,
                reqSubIDs = new List<int> { 904422, 904001, 903829 },
                userPreferredLanguageID=App.UserSession.LoggedonUser.userPreferredLanguageID,
                loggedonUser = App.UserSession.LoggedonUser
            };
        }
        #endregion
    }
}
