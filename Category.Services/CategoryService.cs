using Category.Data;
using Category.Models;
using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new CategoryNew()
                {
                    CategoryTitle = model.CategoryTitle
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e =>
                            new CategoryListItem
                            {
                                CategoryId = e.CategoryId,
                                CategoryTitle = e.CategoryTitle
                            }
                        );
                return query.ToArray();
            }
        }
    }

}
