using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;

namespace Parking.Pages.PrcTable
{
    public class DeleteModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public DeleteModel(Parking.Data.StoreDataContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PriceTable = await _context.PriceTable.FindAsync(id);

            if (PriceTable != null)
            {
                _context.PriceTable.Remove(PriceTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
