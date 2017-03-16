using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DiscourseDotNet.Lib;
using DiscourseDotNet.Request;
using DiscourseDotNet.Response.Get;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static GetUserModel GetUser(this DiscourseApi api, string username)
        {
            var path = String.Format("/users/{0}.json", username);
            return api.ExecuteRequest<GetUserModel>(path, Method.GET);
        }

        public static ResultState UpdateUserEmail(this DiscourseApi api, string username, string newEmail, string apiUserName = DefaultUsername)
        {
            var path = String.Format("/users/{0}/preferences/email", username);
            var data = new UpdateEmail(newEmail);

            var result = api.ExecuteRequest<RestResponse>(path, Method.PUT, true, apiUserName, null, data);

            switch (result.StatusCode)
            {
                case (HttpStatusCode) 422:
                    return ResultState.Unchanged;
                case HttpStatusCode.Accepted:
                    return ResultState.Modified;
                default:
                    return ResultState.Error;
            }
        }
    }
}
