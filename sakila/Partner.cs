using System;
using System.Collections.Generic;

namespace Vika_Automate.sakila
{
    public partial class Partner
    {
        public int IdPartner { get; set; }
        public string FioPartner { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Advertising> Advertisings { get; set; }

        public Partner()
        {
            Advertisings = new HashSet<Advertising>();
        }
    }
}
