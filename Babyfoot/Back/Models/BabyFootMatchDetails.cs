using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("baby_foot_token")]
    public class BabyFootMatchDetails
    {
        [Key]
        [Column("id")]
        public int BabyFootMatchDetailsID { get; private set; }

        [Column("baby_foot_match_id")]
        public int BabyFootMatchID { get; private set; }

        [Column("team1")]
        public int Team1ID { get; private set; }

        [Column("score1")]
        public double Team1Score { get; private set; }

        [Column("team2")]
        public int Team2ID { get; private set; }

        [Column("score2")]
        public double Team2Score { get; private set; }

        /* CONSTRUCTOR */
        public BabyFootMatchDetails() { }
    }
}