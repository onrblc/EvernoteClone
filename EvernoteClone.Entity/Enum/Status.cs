using System.ComponentModel.DataAnnotations;

namespace EvernoteClone.Entity.Enum
{
    public enum Status
    {
        [Display(Name = "Aktif")]
        Active = 0,
        [Display(Name = "Pasif")]
        Passive = 1
    }
}
