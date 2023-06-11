using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Brand
    {
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(50)"), StringLength(50, ErrorMessage = "Marka Adı {0} karakterden uzun olamaz.")]
        [Display(Name ="Marka Adı")]
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
