using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Pages.PrcTable
{
    public class EditModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public EditModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PriceTable PriceTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PriceTable = await _context.PriceTable.FirstOrDefaultAsync(m => m.Id == id);

            if (PriceTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var priceTableToUpdate = await _context.PriceTable.FindAsync(id);

            if (priceTableToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<PriceTable>(
                priceTableToUpdate,
                "priceTable",
                p => p.HourPrice, p => p.ExtraHourPrice, p => p.Description, p => p.EntryDate, p => p.DepartureDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PriceTableExists(int id)
        {
            return _context.PriceTable.Any(e => e.Id == id);
        }
    }
}
