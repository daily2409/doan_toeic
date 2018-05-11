namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        public int ID { get; set; }

        public int ROL_ID { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(20)]
        public string PHONE_NUMBER { get; set; }

        public string ADDRESS { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public virtual ROLE ROLE { get; set; }
    }
}
