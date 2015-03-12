using System.Web.Mvc;

namespace HomeShareMVC.Areas.Boutique
{
    public class BoutiqueAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Boutique";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Boutique_default",
                "Boutique/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}