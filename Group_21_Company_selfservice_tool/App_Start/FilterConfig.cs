using System.Web;
using System.Web.Mvc;

namespace Group_21_Company_selfservice_tool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
