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
    public class Slide
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Slayt Başlığı Girilmelidir")]
        [Column(TypeName ="nvarchar(60)"), StringLength(60, ErrorMessage = "Slayt Başlığı {0} karakterden uzun olamaz.")]
        [Display(Name ="Slayt Başlığı")]
        public string SlideTitle { get; set; }

        [Required(ErrorMessage = "Slayt Açıklaması Girilmelidir")]
        [Column(TypeName = "nvarchar(60)"), StringLength(60, ErrorMessage = "Slayt Açıklaması {0} karakterden uzun olamaz.")]
        [Display(Name = "Slayt Açıklaması")]
        public string SlideDescription { get; set; }

        [Required(ErrorMessage ="Slayt Fiyatı Girilmelidir")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Slayt Fiyat")]
        public decimal SlidePrice { get; set; }

        [Required(ErrorMessage = "Slayt Fotoğrafı Girilmelidir")]
        [Column(TypeName = "nvarchar(150)"), StringLength(150, ErrorMessage = "Slayt Fotoğrafı {0} karakterden uzun olamaz.")]
        [Display(Name = "Slayt Fotoğrafı")]
        public string SlidePicture { get; set; }

        [Required(ErrorMessage = "Slayt Linki Girilmelidir")]
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Slayt Linki")]
        public string SlideLink { get; set; }
    }
}
