using LoadApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Dto
{
    public class LoanDto
    {
        public int id { get; set; }
        public string Status { get; set; } = "Prestado"; //esta Prestado o Devuelto

        public int ThingId { get; set; }

        public int PersonId { get; set; }
    }
}
