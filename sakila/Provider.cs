using System;
using System.Collections.Generic;

namespace Vika_Automate.sakila
{
    public partial class Provider
    {
        public Provider()
        {
            Productions = new HashSet<Production>();
            RawMaterials = new HashSet<RawMaterial>();
        }

        public int IdProvider { get; set; }
        public string FioProvider { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string CompanyName { get; set; } = null!;

        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
    }
}
