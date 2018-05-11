namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESULT")]
    public partial class RESULT
    {
        public int ID { get; set; }

        public double? SCORE { get; set; }

        public DateTime? TEST_DAY { get; set; }
    }
}
