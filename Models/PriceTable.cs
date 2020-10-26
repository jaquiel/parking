using System;
using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class PriceTable
    {   
        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public double HourPrice { get; set; }
        public double ExtraHourPrice { get; set; }

        public DateTime EntryDate { get; set; }
        
        public DateTime DepartureDate { get; set; }     
    }
}