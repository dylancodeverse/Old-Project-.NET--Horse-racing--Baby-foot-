using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("player")]
    public class Player
    {
        [Key]
        [Column("id")]
        public int PlayerID { get; private set; }

        [Column("person_id")]
        public int PersonID { get; private set; }

        [Column("player_name")]
        public String? PlayerName { get; private set; }

        /* CONSTRUCTOR */
        public Player() { }
    }
}