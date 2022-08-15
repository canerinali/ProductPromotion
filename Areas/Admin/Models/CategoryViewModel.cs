using Entities.Abstract;
using System.Collections.Generic;

namespace ProductPromotion.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public List<Category> ListCategory { get; set; }
        public Category Category { get; set; }
    }
}
