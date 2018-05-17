namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("READING")]
    public partial class READING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public READING()
        {
            QUESTIONS = new HashSet<QUESTION>();
        }

        public int ID { get; set; }

        public int? TES_ID { get; set; }

        public int PAR_ID { get; set; }

        public string CONTENT { get; set; }

        public int? LEVEL { get; set; }

        public int? TYPE { get; set; }

        public virtual PART PART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
