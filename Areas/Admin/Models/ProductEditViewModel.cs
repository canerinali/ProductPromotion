using Entities.Abstract;
using System.Collections.Generic;

namespace ProductPromotion.Areas.Admin.Models
{
    public class ProductEditViewModel
    {
        public List<Photo> Photo { get; set; }
        public Product Product { get; set; }
    }
}
