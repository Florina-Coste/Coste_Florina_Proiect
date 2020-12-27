using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;                // folosite pentru a seta diferite constrangeri
using System.ComponentModel.DataAnnotations.Schema;         // sau valori predefinite

namespace Coste_Florina_Proiect.Models
{
    public class Clothes
    {
        public int ID { get; set; }

        [Required, StringLength(500, MinimumLength = 15)]       // max=500 caractere & min=15 caractere
        [Display(Name = "Clothes")]    // specifica modul in care dorim sa afisam numele unui camp
        public string Name { get; set; }    // in acest caz "Name" - "Clothes" 
        public string Size { get; set; }

        [Range(1, 2500)]        // interval valid pentru campul "Price"
        [Column(TypeName = "decimal(6, 2)")]    //permite Entity Framework Core sa mapeze corect proprietatea
        public decimal Price { get; set; }      // price Price, permitand valori cu 2 zecimale

        [DataType(DataType.Date)]
        public DateTime DateOfAppearance { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }        // navigation property
        public ICollection<ClothesCategory> ClothesCategories { get; set; }
    }
}
