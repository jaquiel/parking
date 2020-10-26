using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Parking.Models;

namespace Parking.Pages.PrcTable
{
    public class CreateModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public CreateModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PriceTable PriceTable { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyPriceTable = new PriceTable();

            if (await TryUpdateModelAsync<PriceTable>(
                 emptyPriceTable,
                 "priceTable",   // Prefix for form value.
                 s => s.Id, s => s.Description, s => s.HourPrice, s => s.ExtraHourPrice, s => s.EntryDate, s => s.DepartureDate))
            {
                _context.PriceTable.Add(emptyPriceTable);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            return Page();
        }
    }
}
