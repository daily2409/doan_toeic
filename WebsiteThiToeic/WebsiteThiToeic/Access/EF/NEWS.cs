namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NEWS
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string TITLE { get; set; }

        [StringLength(500)]
        public string SUMMARY { get; set; }

        public string CONTENT { get; set; }
    }
}
