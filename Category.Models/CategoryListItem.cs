using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Models
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }

        [Display(Name ="Category Title")]
        public string CategoryTitle { get; set; }
    }
}
