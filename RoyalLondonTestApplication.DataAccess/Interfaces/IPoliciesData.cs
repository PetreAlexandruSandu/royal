using RoyalLondonTestApplication.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalLondonTestApplication.DataAccess.Interfaces
{
    public interface IPoliciesData
    {
        /// <summary>
        /// Get all insurance policies 
        /// </summary>
        /// <returns>List of Policy details</returns>
        List<Policy> GetPolicies();

        /// <summary>
        /// Create XML result file with the policies maturity values
        /// </summary>
        void CreateXmlFile(List<Maturity> model);
    }
}
