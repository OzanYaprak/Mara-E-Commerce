using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Admin
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [Column(TypeName ="nvarchar(80)"), StringLength(80, ErrorMessage = "Adınız {0} karakterden uzun olamaz.")]
        [Display(Name ="Ad")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [Column(TypeName = "nvarchar(60)"), StringLength(60, ErrorMessage = "Soyad {0} karakterden uzun olamaz.")]
        [Display(Name = "Soyad")]
        public string AdminSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [Column(TypeName = "nvarchar(25)"), StringLength(25, ErrorMessage = "Kullanıcı adı {0} karakterden uzun olamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string AdminUsername { get; set; }

        [Required(ErrorMessage = "Lütfen bir e-posta giriniz.")]
        [Column(TypeName = "nvarchar(50)"), StringLength(50, ErrorMessage = "E-posta {0} karakterden uzun olamaz.")]
        [Display(Name = "E-posta")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Lütfen bir e-posta giriniz.")]
        [Column(TypeName = "nvarchar(50)"), StringLength(50, ErrorMessage = "E-posta {0} karakterden uzun olamaz.")]
        [Display(Name = "E-posta")]
        public string AdminPhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre girilmelidir.")]
        [Column(TypeName = "nvarchar(32)"), StringLength(32, ErrorMessage = "Şifreniz {0} karakterden uzun olamaz.")]
        [Display(Name = "Şifre")]
        public string AdminPassword { get; set; }

        [Display(Name = "Hesap oluşturulma tarihi")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Son giriş tarihi")]
        public DateTime LastLoginDate { get; set; }

        [Column(TypeName = "nvarchar(20)"), StringLength(20)]
        [Display(Name = "Son giriş yapılan IP numarası")]
        public string LastLoginIPNo { get; set; }

        [Display(Name = "Hesap durumu")]
        public bool ActiveStatus { get; set; }
    }
}
