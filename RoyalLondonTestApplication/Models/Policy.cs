#region Used Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace RoyalLondonTestApplication.Models
{
    public class Policy
    {
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public Int64 Premiums { get; set; }

        public bool Membership { get; set; }

        public Int64 DiscretionaryBonus { get; set; }

        public decimal UpliftPercentage { get; set; }
    }
}