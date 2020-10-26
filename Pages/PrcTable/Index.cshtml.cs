using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Pages.PrcTable
{
    public class IndexModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public IndexModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        public IList<PriceTable> PriceTable { get;set; }

        public async Task OnGetAsync()
        {
            PriceTable = await _context.PriceTable            
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
