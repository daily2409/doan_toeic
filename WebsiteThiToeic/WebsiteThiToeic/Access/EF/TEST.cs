namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEST")]
    public partial class TEST
    {
        public int ID { get; set; }

        public int? LIS_ID { get; set; }

        public int? RED_ID { get; set; }

        public virtual LISTENNING LISTENNING { get; set; }

        public virtual READING READING { get; set; }
    }
}
