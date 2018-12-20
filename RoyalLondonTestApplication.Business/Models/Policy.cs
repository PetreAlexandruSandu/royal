#region Used Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace RoyalLondonTestApplication.Business.Models
{
    public class Policy
    {
        /// <summary>
        /// Policy number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Policy date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Policy premiums
        /// </summary>
        public Int64 Premiums { get; set; }

        /// <summary>
        /// Policy membership value
        /// </summary>
        public bool Membership { get; set; }

        /// <summary>
        /// Policy bonus
        /// </summary>
        public Int64 DiscretionaryBonus { get; set; }

        /// <summary>
        /// Policy uplift percentage
        /// </summary>
        public decimal UpliftPercentage { get; set; }
    }
}
