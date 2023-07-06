using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DACS.Models;

namespace DACS.Models
{
    public class Product_Category
    {
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
    }
}