global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Shared.Presentation;

using ProductManagement.Interface.Contracts.Products.Models;
using ProductManagement.Interface.Contracts.Products.Services;

namespace ProductManagement.Presentation.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductController(IProductFacadeService facadeService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<JsonResponse<Guid>> Create(CreateProductModel model)
        {
            return await facadeService.Create(model);
        }
        
        [HttpPut("modify")]
        public async Task Modify(ModifyProductModel model)
        {
            await facadeService.Modify(model);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await facadeService.Delete(new DeleteProductModel { Id = id });
        }
    }
}
