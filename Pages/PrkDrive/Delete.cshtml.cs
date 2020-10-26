using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Pages.PrkDrive
{
    public class DeleteModel : PageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public DeleteModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkingDrive ParkingDrive { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingDrive = await _context.ParkingDrive.FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingDrive == null)
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

            ParkingDrive = await _context.ParkingDrive.FindAsync(id);

            if (ParkingDrive != null)
            {
                _context.ParkingDrive.Remove(ParkingDrive);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
