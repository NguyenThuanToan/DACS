using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int IdProduct { get; set; }
        [DisplayName("Sản phẩm")]
        public string NameProduct { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImageProduct { get; set; }
        public double? TotalMoney
        {
            get
            {
                return Quantity * Price;
            }
        }
        [Column(TypeName = "date")]
        public DateTime? manufacturedate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expiry { get; set; }
    }
}