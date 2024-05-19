using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("team")]
    public class Team
    {
        [Key]
        [Column("id")]
        public int TeamID { get; private set; }

        [Column("name")]
        public String? Name { get; private set; }

        /* CONSTRUCTOR */
        public Team() { }
    }
}