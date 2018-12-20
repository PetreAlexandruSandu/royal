#region Used Namespaces
using RoyalLondonTestApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace RoyalLondonTestApplication.Business.Interfaces
{
    public interface IPoliciesComponent
    {
        /// <summary>
        /// Get insurance policies 
        /// </summary>
        /// <returns>List of Policy details</returns>
        List<Policy> GetPolicies();

        /// <summary>
        /// Compute policies maturity
        /// </summary>
        /// <returns>List of Policy Maturity details</returns>
        List<Maturity> ComputeMaturity();
    }
}
