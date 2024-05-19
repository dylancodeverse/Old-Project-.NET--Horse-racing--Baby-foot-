using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
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

        /* CONSTRUCTOR */
        public Person() { }
    }
}