using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Data
{
    public class CategoryNew
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryTitle { get; set; }
    }
}
