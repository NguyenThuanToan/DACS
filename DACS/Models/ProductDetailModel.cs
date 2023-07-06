using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;

namespace DACS.Models
{
    public class ProductDetailModel
    {
        public Product objProduct { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Product> ListProduct { get; set; }
    }
}