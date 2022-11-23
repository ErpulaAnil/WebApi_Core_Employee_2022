using System.ComponentModel.DataAnnotations;

namespace WebApi_BussenissLayer_TSRTC_Passenger.Models
{
    public class TsRtc
    {
        [Key]
        public int Id { get; set; } 
        [Required] 
        public string? PassengerName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? BusName { get; set;}
        [Required]
        public string? FromPlace { get; set;}
        [Required]
        public string? ToPlace { get; set; }

    }
}
