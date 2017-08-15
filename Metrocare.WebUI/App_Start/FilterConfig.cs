using System.Web;
using System.Web.Mvc;

namespace Metrocare.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new HandleErrorAttribute() { View = "Exception" });
        }
    }
}