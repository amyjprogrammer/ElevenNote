using Category.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {

        public IHttpActionResult Get()
        {
            var categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }
        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }
    }
}
