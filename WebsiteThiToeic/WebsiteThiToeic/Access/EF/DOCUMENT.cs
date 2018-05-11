namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCUMENT")]
    public partial class DOCUMENT
    {
        public int ID { get; set; }

        public string URL { get; set; }

        public int? TYPE { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }
    }
}
