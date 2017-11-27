using System.Web.Mvc;

namespace ItemRendererDemoWebsite.Controllers
{
    public class MasterWidgetController : Controller
    {
        
        public ActionResult Index()
        {
            var datasourceItem = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;

            // Make this more generic by getting the name of the folder from the rendering parameters
            // we can provide a default in the component defintition item
            var renderingParameters = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Parameters;
            
            // Provide a fallback string value to avoid an error if it is null - just as well provide a default in code.
            var widgetsFolderName = renderingParameters["FolderName"] ?? "Controls";

            var widgets = datasourceItem?.Children[widgetsFolderName]?.Children;

            return widgets == null ? (ActionResult) new EmptyResult() : View(widgets);
        }
    }
}