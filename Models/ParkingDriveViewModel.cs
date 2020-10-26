using System;

namespace Parking.Models
{
    public class ParkingDriveViewModel
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ParkedAt { get; set; }
        public DateTime DisplacedAt { get; set; }
        public string Duration { get; set; }
        public string TimePayment { get; set; }
        public string HourPrice { get; set; }
        public string TotalPayment { get; set; }

    }
}