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
    public class IndexModel : PageModel
    {
        private readonly Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext _context;

        public IndexModel(Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext context)
        {
            _context = context;
        }

        public IList<Clothes> Clothes { get;set; }
        public ClothesData ClothesD { get; set; }
        public int ClothesID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ClothesD = new ClothesData();
            ClothesD.Clothes = await _context.Clothes
                .Include(b => b.Brand)
                .Include(b => b.ClothesCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();
            if(id != null)
            {
                ClothesID = id.Value;
                Clothes clothes = ClothesD.Clothes
                    .Where(i => i.ID == id.Value).Single();
                ClothesD.Categories = clothes.ClothesCategories.Select(s => s.Category);
            }
        }
    }
}
