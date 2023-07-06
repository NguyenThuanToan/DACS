namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int? IdCategory { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(200)]
        public string NameProduct { get; set; }

        public string DescriptionProduct { get; set; }

        public int? QuantityOfProduct { get; set; }

        public double? Price { get; set; }

        public bool StatusProduct { get; set; }

        [StringLength(200)]
        public string ImageProduct { get; set; }

        [Column(TypeName = "date")]
        public DateTime? manufacturedate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expiry { get; set; }

        [StringLength(200)]
        public string ImageBrand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
