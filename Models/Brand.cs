using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coste_Florina_Proiect.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Clothes> Haine { get; set; }   // navigation property 
    }
}
