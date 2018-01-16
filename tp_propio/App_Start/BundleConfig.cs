using System.Web;
using System.Web.Optimization;

namespace tp_propio
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap") //crea u nuevo bundle de scripts
                .Include(//se especifican los scripts a usar
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css") //crea u nuevo bundle de estilos
                .Include(//se especifican las hojas de estilos a usar
                      "~/Content/bootstrap.css",
                      "~/css/Estilos.css"));

            bundles.Add(new StyleBundle("~/Content/admin-css").Include("~/css/EstilosAdmin.css"));

            bundles.Add(new ScriptBundle("~/bundles/CancelarReserva").Include("~/js/CancelarReserva.js"));

            bundles.Add( new ScriptBundle("~/bundles/Interfaz").Include("~/js/interfaz.js"));
        }
    }
}
