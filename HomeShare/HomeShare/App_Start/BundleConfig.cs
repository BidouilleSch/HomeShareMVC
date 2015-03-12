using System.Web;
using System.Web.Optimization;

namespace HomeShareMVC
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le regroupement, rendez-vous sur http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/jquery.ba-cond.min.js",     
                        "~/Scripts/jquery.slitslider.js"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/modernizr.custom.79639"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.css",
                      "~/Content/style.css",
                      "~/Content/custom.css"));
        }
    }
}
