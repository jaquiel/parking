using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Models;
using System;
using System.Globalization;

namespace Parking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        private static CultureInfo _brazilianCurrency; 

        public IndexModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
            _brazilianCurrency = new CultureInfo("pt-BR", false);
        }

        public IList<PriceTable> PriceTable { get; set; }
        public IList<ParkingDrive> ParkingDrive { get; set; }
        public IList<ParkingDriveViewModel> ParkingDriveVM { get; set; }

        static double GetDiff(DateTime ParkedAt, DateTime DisplacedAt){

            TimeSpan diff = (DisplacedAt - ParkedAt);

            if (diff.TotalMinutes <= 30)
            {
                return 0.5;
            }
            else if (diff.Minutes <= 10)
            {                
                return Math.Truncate(diff.TotalHours);
            }
            else if (diff.Minutes > 10)
            {
                return Math.Truncate(diff.TotalHours) + 1;
            }
                
            return 0;         
        }

        static string FormatString(double value)
        {
            return value.ToString("C", _brazilianCurrency);
        }

        static string FormatTime(double value)
        {
            double hours = Math.Truncate(value);
            double minutes = (value * 60) - (hours * 60);
            string strResult =  hours.ToString().PadLeft(2,'0') + ":" + Math.Truncate(minutes).ToString().PadLeft(2, '0');
            return strResult;
        }

        static double GetTotal(double value, double PriceHour, double ExtraPriceHour)
        {
            double Result;
            double TruncValue = Math.Truncate(value);
            TruncValue = Math.Truncate(value);
            if (TruncValue > 1) 
            {
                Result = ((TruncValue - 1) * ExtraPriceHour) + PriceHour;
            }
            else 
            if (TruncValue < 1)
            {
                Result = value * PriceHour;
            }
            else
            {
                Result = TruncValue * PriceHour;
            }
            return Result;
        }

        public async Task OnGetAsync()
        {

            ParkingDriveVM = await _context.ParkingDrive
                    .Select(p => new ParkingDriveViewModel
                    {
                        Id = p.Id,
                        LicensePlate = p.LicensePlate,
                        ParkedAt = p.ParkedAt,
                        DisplacedAt = p.DisplacedAt,
                        Duration = FormatTime((p.DisplacedAt - p.ParkedAt).TotalHours),
                        TimePayment = FormatTime(GetDiff(p.ParkedAt, p.DisplacedAt)),
                        HourPrice = FormatString(p.PriceTable.HourPrice),
                        TotalPayment = FormatString( GetTotal(GetDiff(p.ParkedAt, p.DisplacedAt), p.PriceTable.HourPrice, p.PriceTable.ExtraHourPrice ))                    
                    }).ToListAsync();
        }        
    }
}

