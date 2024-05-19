using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("baby_foot")]
    public class BabyFoot
    {
        [Key]
        [Column("id")]
        public int BabyFootID { get; private set; }

        [Column("owner")]
        public int Owner { get; private set; }

        /* CONSTRUCTOR */
        public BabyFoot() { }
    }
}