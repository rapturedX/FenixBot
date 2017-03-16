using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscourseDotNet
{
    public partial class DiscourseApi
    {
        private static DiscourseApi _instance;

        public static DiscourseApi GetInstance(string baseUrl, string apiKey)
        {
            if (_instance == null || _instance.BaseUrl != baseUrl ||
                _instance.ApiKey != apiKey)
            {
                _instance = new DiscourseApi(baseUrl, apiKey);
            }
            return _instance;
        }
    }
}
