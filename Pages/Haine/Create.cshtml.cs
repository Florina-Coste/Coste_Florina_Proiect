using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coste_Florina_Proiect.Data;
using Coste_Florina_Proiect.Models;

namespace Coste_Florina_Proiect.Pages.Haine
{
    public class CreateModel : ClothesCategoriesPageModel
    {
        private readonly Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext _context;

        public CreateModel(Coste_Florina_Proiect.Data.Coste_Florina_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            var clothes = new Clothes();
            clothes.ClothesCategories = new List<ClothesCategory>();
            PopulateAssignedCategoryData(_context, clothes); 
            return Page();
        }

        [BindProperty]
        public Clothes Clothes { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync (string[] selectedCategories)
        {
            var newClothes = new Clothes();
            if (selectedCategories != null)
            {
                newClothes.ClothesCategories = new List<ClothesCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ClothesCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newClothes.ClothesCategories.Add(catToAdd);
                }
            }
            if(await TryUpdateModelAsync<Clothes>(
                newClothes,
                "Clothes",
                i => i.Name, i => i.Size,
                i => i.Price, i => i.DateOfAppearance, i => i.BrandID))
            {
                _context.Clothes.Add(newClothes);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newClothes);
            return Page();
        }
    }
}
