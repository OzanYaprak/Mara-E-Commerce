using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Ürün Adı Girilmelidir")]
        [Column(TypeName ="nvarchar(80)"), StringLength(80, ErrorMessage = "Ürün Adı {0} karakterden uzun olamaz.")]
        [Display(Name ="Ürün Adı")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(160)"), StringLength(160, ErrorMessage = "Ürün Açıklaması {0} karakterden uzun olamaz.")]
        [Display(Name = "Ürün Açıklaması")]
        public string ProductDescription { get; set; }

        [Column(TypeName = "nvarchar(160)"), StringLength(160, ErrorMessage = "Ürün Detayı {0} karakterden uzun olamaz.")]
        [Display(Name = "Ürün Detayı")]
        public string ProductDetail { get; set; }

        [Required(ErrorMessage = "Ürün Fiyatı Girilmelidir")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Ürün Fiyat")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Ürün Stok Sayısı")]
        public int ProductStock { get; set; }

        [Display(Name = "Marka")]
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
    }
}
