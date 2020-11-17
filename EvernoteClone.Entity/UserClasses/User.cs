using EvernoteClone.Entity.BaseClasses;
using EvernoteClone.Entity.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvernoteClone.Entity.UserClasses
{
    public class User : BaseObject
    {
        [DisplayName("Adı")]
        [Required (ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0}, alanı en az {2}, en fazla {1} karakter olabilir.")]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(50, MinimumLength =2, ErrorMessage = "{0}, alanı en az {2}, en fazla {1} karakter olabilir.")]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0}, alanı en az {2}, en fazla {1} karakter olabilir.")]
        public string UserName { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "{0}, alanı en az {2}, en fazla {1} karakter olabilir.")]
        public string Password { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public DateTime DayOfBirth { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MinLength (4, ErrorMessage = "{0}, alanı en az {1} karakter olabilir.")]
        public string Email { get; set; }

        [DisplayName("Bölümü")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public Department Department { get; set; }
    }
}
