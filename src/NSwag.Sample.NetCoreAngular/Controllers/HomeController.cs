using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using NSwag.SwaggerGeneration.AspNetCore;
using NSwag.SwaggerGeneration.WebApi;

namespace NSwag_Sample_NetCoreAngular.Controllers
{
    [SwaggerIgnore]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var generator = new WebApiToSwaggerGenerator(new WebApiToSwaggerGeneratorSettings());
            var controllerTypes = WebApiToSwaggerGenerator.GetControllerClasses(GetType().GetTypeInfo().Assembly);

            var document = await generator.GenerateForControllersAsync(controllerTypes);
            return Content(document.ToJson());
        }

        public async Task<IActionResult> New([FromServices] Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionGroupCollectionProvider groups)
        {
            var generator = new AspNetCoreToSwaggerGenerator(new AspNetCoreToSwaggerGeneratorSettings());

            var document = await generator.GenerateAsync(groups.ApiDescriptionGroups);
            return Content(document.ToJson());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
