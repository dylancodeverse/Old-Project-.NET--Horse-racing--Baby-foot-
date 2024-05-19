using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baby_foot.Models
{
    [Table("person_monetary_flow")]
    public class PersonMonetaryFlow
    {
        [Key]
        [Column("id")]
        public int PersonMonetaryFlowID { get; private set; }

        [Column("date_time")]
        public DateTime DateTime { get; private set; }

        [Column("person_id")]
        public int PersonID { get; private set; }

        [Column("status_code")]
        public String? StatusCode { get; private set; }

        [Column("amount")]
        public double Amount { get; private set; }

        /* CONSTRUCTOR */
        public PersonMonetaryFlow() { }
    }
}