using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.PrkDrive
{
    public class DetailsModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public DetailsModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        public ParkingDrive ParkingDrive { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingDrive = await _context.ParkingDrive
                 .AsNoTracking()
                 .Include(p => p.PriceTable)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingDrive == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
