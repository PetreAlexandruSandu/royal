#region Used Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 
#endregion

namespace RoyalLondonTestApplication.DataAccess.Models
{
    public class Policy
    {
        /// <summary>
        /// Policy number
        /// </summary>
        [XmlElement(ElementName = "PolicyNumber")]
        public string Number { get; set; }

        /// <summary>
        /// Policy date
        /// </summary>
        [XmlIgnoreAttribute]
        public DateTime Date { get; set; }

        /// <summary>
        /// Policy premiums
        /// </summary>
        [XmlIgnoreAttribute]
        public Int64 Premiums { get; set; }

        /// <summary>
        /// Policy membership value
        /// </summary>
        [XmlIgnoreAttribute]
        public bool Membership { get; set; }

        /// <summary>
        /// Policy bonus
        /// </summary>
        [XmlIgnoreAttribute]
        public Int64 DiscretionaryBonus { get; set; }

        /// <summary>
        /// Policy uplift percentage
        /// </summary>
        [XmlIgnoreAttribute]
        public decimal UpliftPercentage { get; set; }
    }
}
