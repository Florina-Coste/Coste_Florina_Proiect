using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coste_Florina_Proiect.Data;
using Coste_Florina_Proiect.Models;

namespace Coste_Florina_Proiect.Pages.Haine
{
    public class EditModel : ClothesCategoriesPageModel
    {
        private readonly Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext _context;

        public EditModel(Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothes Clothes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Clothes = await _context.Clothes.FirstOrDefaultAsync(m => m.ID == id);
            Clothes = await _context.Clothes
                .Include(b => b.Brand)
                .Include(b => b.ClothesCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Clothes == null)
            {
                return NotFound();
            }

            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 

            PopulateAssignedCategoryData(_context, Clothes);

            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothesToUpdate = await _context.Clothes
            .Include(i => i.Brand)
            .Include(i => i.ClothesCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (clothesToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Clothes>(
            clothesToUpdate,
            "Clothes",
            i => i.Name, i => i.Size,
            i => i.Price, i => i.DateOfAppearance, i => i.Brand))
            {
                UpdateClothesCategories(_context, selectedCategories, clothesToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateClothesCategories(_context, selectedCategories, clothesToUpdate);
            PopulateAssignedCategoryData(_context, clothesToUpdate);
            return Page();
        }

        private bool ClothesExists(int id)
        {
            return _context.Clothes.Any(e => e.ID == id);
        }
    }
}
