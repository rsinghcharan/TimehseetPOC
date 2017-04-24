#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models.Response
{
    /// <summary>
    /// ResponseBase class
    /// </summary>
    public class ResponseBase
    {
        public bool ResultSuccess { get; set; }
        private List<ResultMessage> resultMessages;
        public ResponseBase()
        {
            resultMessages = new List<ResultMessage>();
        }
        public List<ResultMessage> ResultMessages
        {
            get { return resultMessages; }
            set { resultMessages = value; }
        }
    }

    /// <summary>
    /// ResultMessage class
    /// </summary>
    public class ResultMessage
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
