using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EvernoteClone.WEB.Models
{
    public class LoginModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "{0}, alanı en fazla {2}, en az {1} karakter olabilir.")]
        public string UserName { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "{0}, alanı en fazla {2}, en az {1} karakter olabilir.")]
        public string Password { get; set; }
    }
}