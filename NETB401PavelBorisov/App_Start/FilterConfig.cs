using System.Web;
using System.Web.Mvc;

namespace NETB401PavelBorisov
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
