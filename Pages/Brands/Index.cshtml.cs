using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coste_Florina_Proiect.Data;
using Coste_Florina_Proiect.Models;

namespace Coste_Florina_Proiect.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext _context;

        public IndexModel(Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; }

        public async Task OnGetAsync()
        {
            Brand = await _context.Brand.ToListAsync();
        }
    }
}
