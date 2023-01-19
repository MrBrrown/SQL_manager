using System;
using System.Collections.Generic;

namespace Vika_Automate.sakila
{
    public partial class Production
    {
        public int IdProduction { get; set; }
        public int IdProduct { get; set; }
        public int IdRawMaterial { get; set; }
        public int IdProvider { get; set; }
        public string NameProduction { get; set; } = null!;
        public string ProductionCity { get; set; } = null!;

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual RawMaterial IdRawMaterialNavigation { get; set; } = null!;
    }
}
