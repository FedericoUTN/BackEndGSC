using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace LoadApi.Entities
{
    public class Loan : EntityBase
    {
        public string Status { get; set; } = "Prestado"; //esta Prestado o Devuelto

       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime CreateDate { get; set; }

        //Solo se llena cuando se devuelve
        public DateTime? ReturnDate { get; set; } 
        public Thing? Thing { get; set; }

        public int ThingId { get; set; }
        
        public Person? Person { get; set; }

        public int PersonId { get; set; }
    }
}
