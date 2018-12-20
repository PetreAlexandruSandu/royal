#region Used Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace RoyalLondonTestApplication.Business.Models
{
    public class Maturity : Policy
    {
        /// <summary>
        /// Maturity value
        /// </summary>
        public decimal Value { get; set; }
    }
}
