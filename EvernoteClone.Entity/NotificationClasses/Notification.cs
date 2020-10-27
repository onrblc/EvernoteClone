using EvernoteClone.Entity.BaseClasses;
using EvernoteClone.Entity.Enum;
using EvernoteClone.Entity.UserClasses;

namespace EvernoteClone.Entity.NotificationClasses
{
    public class Notification : BaseObject
    {
        public int NotiId { get; set; }

        public string Description { get; set; }

        public string ContAction { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public NotificationStatus NotificationStatus { get; set; }

    }
}
