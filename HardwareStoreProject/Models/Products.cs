using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HardwareStoreApp.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name Required.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is Required.")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Qty is Required.")]

        public int Qty { get; set; }

        public string Remarks { get; set; }
    }

    public class EFCodeFirstEntieis : DbContext
    {
        public DbSet<Products> products { get; set; }

    }

}