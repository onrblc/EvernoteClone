using EvernoteClone.Entity.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvernoteClone.Entity.BaseClasses
{
    public class BaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [Column(TypeName = "datetime2")]
        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Oluşturan Kişi")]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [DisplayName("Son Güncelleme Tarihi")]
        [Column(TypeName ="datetime2")]
        [ScaffoldColumn(false)]
        public DateTime LastModifiedOn { get; set; }

        [DisplayName("Son Değiştiren Kişi")]
        [ScaffoldColumn(false)]
        public string LastModifiedBy { get; set; }

        [DisplayName("Silindi Bilgisi")]
        [ScaffoldColumn(false)]
        public ObjectStatus ObjectStatus { get; set; }

        [DisplayName("Aktiflik Bilgisi")]
        [ScaffoldColumn(false)]
        public Status Status { get; set; }

    }
}
