using Entities.Abstract;
using System.Collections.Generic;

namespace ProductPromotion.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public List<Photo> Photo { get; set; }
        public List<Product> Product { get; set; }
    }
}
