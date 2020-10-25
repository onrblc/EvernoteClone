using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvernoteClone.Entity.UserClasses
{
    class UserDetail 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Son Giriş")]
        [Column(TypeName = "datetime2")]
        public DateTime SessionDate { get; set; }

        [DisplayName("Geçirilen Süre")]
        [Column(TypeName = "datetime2")]
        public DateTime SessionTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
