namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PART")]
    public partial class PART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PART()
        {
            LISTENNINGs = new HashSet<LISTENNING>();
            READINGs = new HashSet<READING>();
        }

        public int ID { get; set; }

        public int TIT_ID { get; set; }

        [StringLength(50)]
        public string CONTENT { get; set; }

        public int? VALUE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LISTENNING> LISTENNINGs { get; set; }

        public virtual TITLE TITLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<READING> READINGs { get; set; }
    }
}
