using System.ComponentModel.DataAnnotations;

namespace EvernoteClone.Entity.Enum
{
    public enum ObjectStatus
    {
        [Display(Name = "Silindi")]
        Deleted = 0,
        [Display(Name = "Silinmedi")]
        NonDeleted = 1
    }
}
