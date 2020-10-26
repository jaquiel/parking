using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Parking.Data;

namespace Parking.Pages.PrkDrive
{
    public class PriceTableDescriptionPageModel : PageModel
    {
        public SelectList PriceTableDescriptionSL { get; set; }

        public void PopulatePriceTablesDropDownList(StoreDataContext _context,
            object selectedPrice = null)
        {
            var priceTablesQuery = from d in _context.PriceTable
                                   orderby d.Description // Sort by description.
                                   select d;

            PriceTableDescriptionSL = new SelectList(priceTablesQuery.AsNoTracking(),
                        "Id", "Description", selectedPrice);
        }       
    }
}