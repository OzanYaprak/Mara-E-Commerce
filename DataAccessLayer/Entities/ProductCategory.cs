using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ProductCategory
    {
        [Display(Name ="Ürün")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
