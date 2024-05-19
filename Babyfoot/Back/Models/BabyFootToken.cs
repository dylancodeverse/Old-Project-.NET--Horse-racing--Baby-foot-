using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("baby_foot_token")]
    public class BabyFootToken
    {
        [Key]
        [Column("id")]
        public int BabyFootTokenID { get; private set; }

        [Column("baby_foot_id")]
        public int BabyFootID { get; private set; }

        [Column("name")]
        public String? Name { get; private set; }

        [Column("token_price")]
        public double TokenPrice { get; private set; }

        [Column("ball_count")]
        public int BallCount { get; private set; }

        [Column("start_date")]
        public DateTime? StartDate { get; private set; }

        [Column("end_date")]
        public DateTime? EndDate { get; private set; }

        /* CONSTRUCTOR */
        public BabyFootToken() { }
    }
}