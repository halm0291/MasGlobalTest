
using System;
using System.Configuration;

namespace MasGlobalTestApi.App_Start
{
    public class General
    {
        public static bool UseHttp
        {
            get
            {
                if (ConfigurationManager.AppSettings["UseHttp"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["UseHttp"]);
                }
                else return false;
            }
        }
    }
}