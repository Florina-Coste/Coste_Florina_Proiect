using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coste_Florina_Proiect.Data;
using Coste_Florina_Proiect.Models;

namespace Coste_Florina_Proiect.Pages.Haine
{
    public class DetailsModel : PageModel
    {
        private readonly Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext _context;

        public DetailsModel(Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext context)
        {
            _context = context;
        }

        public Clothes Clothes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothes = await _context.Clothes.FirstOrDefaultAsync(m => m.ID == id);

            if (Clothes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
