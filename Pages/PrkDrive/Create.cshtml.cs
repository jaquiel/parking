using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking.Models;

namespace Parking.Pages.PrkDrive
{
    public class CreateModel : PriceTableDescriptionPageModel
    {
        private readonly Parking.Data.StoreDataContext _context;

        public CreateModel(Parking.Data.StoreDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulatePriceTablesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public ParkingDrive ParkingDrive { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyParkingDrive = new ParkingDrive();

            if (await TryUpdateModelAsync<ParkingDrive>(
                 emptyParkingDrive,
                 "parkingDrive",   // Prefix for form value.
                 s => s.Id, s => s.PriceTableID, s => s.LicensePlate, s => s.ParkedAt, s => s.DisplacedAt))
            {
                _context.ParkingDrive.Add(emptyParkingDrive);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            PopulatePriceTablesDropDownList(_context, emptyParkingDrive.PriceTableID);
            return Page();
        }
    }
}
