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
    public class ProductPicture
    {
        public int ID { get; set; }


        [Column(TypeName ="nvarchar(120)"), StringLength(120, ErrorMessage = "Ürün Fotoğraf adı {0} karakterden uzun olamaz.")]
        [Display(Name ="Ürün Fotoğraf Adı")]
        public string PictureName { get; set; }

        [Column(TypeName = "nvarchar(150)"), StringLength(150, ErrorMessage = "Fotoğraf URL {0} karakterden uzun olamaz.")]
        [Display(Name = "Ürün Fotoğraf URL")]
        public string PictureURL { get; set; }

        [Display(Name = "Ürün")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
