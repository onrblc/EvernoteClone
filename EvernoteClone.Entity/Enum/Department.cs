using System.ComponentModel.DataAnnotations;

namespace EvernoteClone.Entity.Enum
{
    public enum Department
    {
        [Display(Name ="Admin")]
        Management = 0,
        [Display(Name = "Kullanıcı")]
        User = 1
    }
}
