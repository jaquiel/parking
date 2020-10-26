using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Pages.PrkDrive
{
    public class IndexModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public IndexModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        public IList<ParkingDrive> ParkingDrive { get;set; }

        public async Task OnGetAsync()
        {
            ParkingDrive = await _context.ParkingDrive
                .Include(c => c.PriceTable)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
