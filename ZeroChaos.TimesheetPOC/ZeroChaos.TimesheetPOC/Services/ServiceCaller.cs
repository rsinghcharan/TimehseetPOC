﻿#region Namespaces
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.IServices;
#endregion
namespace ZeroChaos.TimesheetPOC.Services
{
    /// <summary>
    /// Service class implementation of IServiceCaller
    /// </summary>
    public class ServiceCaller : IServiceCaller
    {
        #region Interface Implementation
        /// <summary>
        /// CallHostService method calls host web api and gets the data.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task CallHostService<TRequest, TResponse>(TRequest request, string methodName, Action<TResponse> callback)
        {
            TResponse jsonResponse = default(TResponse);
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.UserSession.CurrentUserInfo.AuthToken);

                HttpResponseMessage response = await client.PostAsync(App.UserSession.SelectedDataCenter + methodName, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var returnedToken = response.Content.ReadAsStringAsync();
                    jsonResponse = JsonConvert.DeserializeObject<TResponse>(returnedToken.Result);
                    callback(jsonResponse);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
