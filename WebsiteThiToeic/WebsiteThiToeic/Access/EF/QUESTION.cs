namespace WebsiteThiToeic.Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTIONS")]
    public partial class QUESTION
    {
        public int ID { get; set; }

        public int? REA_ID { get; set; }

        public int? LIS_ID { get; set; }

        [StringLength(200)]
        public string CONTENT { get; set; }

        [StringLength(200)]
        public string ANSWER_A { get; set; }

        [StringLength(200)]
        public string ANSWER_B { get; set; }

        [StringLength(200)]
        public string ANSWER_C { get; set; }

        [StringLength(200)]
        public string ANSWER_D { get; set; }

        public int? CORRECT_ANSWER { get; set; }

        public virtual LISTENNING LISTENNING { get; set; }

        public virtual READING READING { get; set; }
    }
}
