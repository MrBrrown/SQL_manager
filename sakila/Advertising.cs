using System;
using System.Collections.Generic;

namespace Vika_Automate.sakila
{
    public partial class Advertising
    {
        public int IdAdvertising { get; set; }
        public int IdPartner { get; set; }
        public int IdProduct { get; set; }
        public string AdFormat { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual Partner IdPartnerNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
