using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("status")]
    public class Status
    {
        [Key]
        [Column("id")]
        public int StatusID { get; private set; }

        [Column("code")]
        public string? Code { get; private set; }

        [Column("description")]
        public string? Description { get; private set; }

        /* CONSTRUCTOR */
        public Status() { }
    }
}