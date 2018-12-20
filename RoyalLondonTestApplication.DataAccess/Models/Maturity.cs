#region Used 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 
#endregion

namespace RoyalLondonTestApplication.DataAccess.Models
{
    [Serializable()]
    public class Maturity : Policy
    {
        /// <summary>
        /// Maturity value
        /// </summary>
        [XmlElement(ElementName = "MaturityValue")]
        public decimal Value { get; set; }
    }
}
