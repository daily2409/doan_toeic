namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THEME")]
    public partial class THEME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THEME()
        {
            VOCABULARies = new HashSet<VOCABULARY>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string CONTENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOCABULARY> VOCABULARies { get; set; }
    }
}
