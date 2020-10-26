using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class ParkingDrive
    {
        [Key]
        public int Id { get; set; }

        public string LicensePlate { get; set; }
        
        public DateTime ParkedAt { get; set; }

        public DateTime DisplacedAt { get; set; }
        
        public int PriceTableID { get; set; }
        
        public PriceTable PriceTable { get; set; }   
    }
}