using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Entity.Enum
{
    public enum NotificationStatus
    {
        [Display(Name = "Görüldü")]
        Seen = 0,
        [Display(Name ="Görülmedi")]
        Unseen = 1
    }
}
