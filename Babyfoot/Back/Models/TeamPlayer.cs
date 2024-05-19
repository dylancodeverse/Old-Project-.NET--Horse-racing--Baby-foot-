using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("team_player")]
    public class TeamPlayer
    {
        [Key]
        [Column("id")]
        public int TeamPlayerID { get; private set; }

        [Column("person_id")]
        public int PersonID { get; private set; }

        [Column("team_id")]
        public int TeamID { get; private set; }

        /* CONSTRUCTOR */
        public TeamPlayer() { }
    }
}