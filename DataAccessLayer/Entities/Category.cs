using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(50)"), StringLength(50, ErrorMessage = "Kategori adı {0} karakterden uzun olamaz.")]
        [Display(Name ="Kategori Adı")]
        public string CategoryName { get; set; }

        [Display(Name = "Ana Kategori")]
        public int? ParentID { get; set; }
        public Category ParentCategory { get; set; }

        [Display(Name = "Alt Kategoriler")]
        public ICollection<Category> SubCategories { get; set;}
    }
}
