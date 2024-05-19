using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace baby_foot.Models
{
    [Table("people")]
    [Keyless]
    public class VPeople
    {
        [Column("id")]
        public int PersonID { get; private set; }

        [Column("name")]
        public String? Name { get; private set; }

        [Column("first_name")]
        public DateTime FirstName { get; private set; }

        [Column("birthdate")]
        public DateTime? Birthdate { get; private set; }

        [Column("address")]
        public String? Address { get; private set; }

        [Column("money")]
        public double Money { get; private set; }

        /* CONSTRUCTOR */
        public VPeople() { }
    }
}