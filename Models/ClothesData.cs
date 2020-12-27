using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coste_Florina_Proiect.Models
{
    public class ClothesData
    {
        public IEnumerable<Clothes> Clothes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ClothesCategory> ClothesCategories { get; set; }
    }
}
