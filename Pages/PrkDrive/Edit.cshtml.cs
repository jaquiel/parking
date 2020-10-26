using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Pages.PrkDrive
{
    public class EditModel : PriceTableDescriptionPageModel 
    {
        private readonly Parking.Data.StoreDataContext _context;

        public EditModel(Parking.Data.StoreDataContext context)
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

            ParkingDrive = await _context.ParkingDrive //.FirstOrDefaultAsync(m => m.Id == id);
               .Include(p => p.PriceTable)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingDrive == null)
            {
                return NotFound();
            }

            PopulatePriceTablesDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingDriveToUpdate = await _context.ParkingDrive.FindAsync(id);

            if (parkingDriveToUpdate == null)
            {
                return NotFound();  
            }

            if (await TryUpdateModelAsync<ParkingDrive>(
                 parkingDriveToUpdate,
                 "parkingDrive",   // Prefix for form value.
                  s => s.Id, s => s.PriceTableID, s => s.LicensePlate, s => s.ParkedAt, s => s.DisplacedAt))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulatePriceTablesDropDownList(_context, parkingDriveToUpdate.PriceTableID);
            return Page();
        }

        // private bool ParkingDriveExists(int id)
        // {
        //     return _context.ParkingDrive.Any(e => e.Id == id);
        // }
    }
}
