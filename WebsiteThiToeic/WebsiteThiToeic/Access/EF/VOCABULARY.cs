namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VOCABULARY")]
    public partial class VOCABULARY
    {
        public int ID { get; set; }

        public int? PIC_ID { get; set; }

        public int THE_ID { get; set; }

        [StringLength(50)]
        public string WORD { get; set; }

        [StringLength(200)]
        public string NOUN { get; set; }

        [StringLength(200)]
        public string VERB { get; set; }

        [StringLength(200)]
        public string ADJECTIVE { get; set; }

        [StringLength(200)]
        public string ADVERB { get; set; }

        [StringLength(200)]
        public string SYNONYM { get; set; }

        public virtual PICTURE PICTURE { get; set; }

        public virtual THEME THEME { get; set; }
    }
}
