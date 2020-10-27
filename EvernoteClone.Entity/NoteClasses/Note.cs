using EvernoteClone.Entity.BaseClasses;
using EvernoteClone.Entity.UserClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvernoteClone.Entity.NoteClasses
{
    public class Note : BaseObject
    {

        [DataType(DataType.MultilineText)]
        [Column(TypeName= "nvarchar(MAX)")]
        [StringLength(600000)]
        public string Description { get; set; }

        public virtual User User { get; set; }

    }
}
