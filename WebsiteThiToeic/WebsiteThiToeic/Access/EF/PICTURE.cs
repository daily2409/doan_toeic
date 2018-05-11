namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PICTURE")]
    public partial class PICTURE
    {
        public int ID { get; set; }

        public string URL { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public virtual VOCABULARY VOCABULARY { get; set; }
    }
}
