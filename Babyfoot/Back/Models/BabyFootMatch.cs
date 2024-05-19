using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("baby_foot_token")]
    public class BabyFootMatch
    {
        [Key]
        [Column("id")]
        public int BabyFootMatchID { get; private set; }

        [Column("baby_foot_id")]
        public int BabyFootID { get; private set; }

        [Column("match_date")]
        public DateTime? MatchDate { get; private set; }

        /* CONSTRUCTOR */
        public BabyFootMatch() { }
    }
}