#region Used Namespaces
using RoyalLondonTestApplication.Business.Helpers;
using RoyalLondonTestApplication.Business.Interfaces;
using RoyalLondonTestApplication.Business.Models;
using RoyalLondonTestApplication.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace RoyalLondonTestApplication.Business.Components
{
    /// <summary>
    /// Policies component implementation
    /// </summary>
    public class PoliciesComponent : IPoliciesComponent
    {
        #region Properties
        /// <summary>
        /// Data access component
        /// </summary>
        private IPoliciesData PoliciesData { get; set; }

        /// <summary>
        /// Management fee for type A policies
        /// </summary>
        private const decimal ManagementFeeTypeA = 3.0m / 100.0m;

        /// <summary>
        /// Management fee for type B policies
        /// </summary>
        private const decimal ManagementFeeTypeB = 5.0m / 100.0m;

        /// <summary>
        /// Management fee for type C policies
        /// </summary>
        private const decimal ManagementFeeTypeC = 7.0m / 100.0m;
        #endregion

        #region Constructor
        public PoliciesComponent(IPoliciesData policiesData)
        {
            this.PoliciesData = policiesData;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Calculate the maturity values for a list of policies
        /// </summary>
        /// <param name="policies">List of policies</param>
        /// <returns>List of maturity values</returns>
        private List<Maturity> ComputeMaturityValues(List<Policy> policies)
        {
            List<Maturity> result = new List<Maturity>();

            foreach (var policy in policies)
            {
                if (policy.Number.StartsWith("A"))
                {
                    result.Add(ComputeMaturityForTypeA(policy));
                }
                else if (policy.Number.StartsWith("B"))
                {
                    result.Add(ComputeMaturityForTypeB(policy));
                }
                else if (policy.Number.StartsWith("C"))
                {
                    result.Add(ComputeMaturityForTypeC(policy));
                }
            }

            return result;
        }

        /// <summary>
        /// Helper method for truncating the decimal values without rounding
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <param name="precision">Precision parameter</param>
        /// <returns>Truncated decimal without rounding</returns>
        private decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }

        /// <summary>
        /// Compute maturity values for type A policy
        /// </summary>
        /// <param name="policy">Policy properties</param>
        /// <returns>Maturity value</returns>
        private Maturity ComputeMaturityForTypeA(Policy policy)
        {
            long bonus = policy.Date < new DateTime(1990, 1, 1) ? policy.DiscretionaryBonus : 0;

            Maturity policyMaturityValue = new Maturity
            {
                Number = policy.Number,
                Value = TruncateDecimal(((policy.Premiums - (policy.Premiums * ManagementFeeTypeA)) + bonus) * (policy.UpliftPercentage / 100 + 1), 2)
            };

            return policyMaturityValue;
        }

        /// <summary>
        /// Compute maturity values for type B policy
        /// </summary>
        /// <param name="policy">Policy properties</param>
        /// <returns>Maturity value</returns>
        private Maturity ComputeMaturityForTypeB(Policy policy)
        {
            long bonus = policy.Membership ? policy.DiscretionaryBonus : 0;

            Maturity policyMaturityValue = new Maturity
            {
                Number = policy.Number,
                Value = TruncateDecimal(((policy.Premiums - (policy.Premiums * ManagementFeeTypeB)) + bonus) * (policy.UpliftPercentage / 100 + 1), 2)
            };

            return policyMaturityValue;
        }

        /// <summary>
        /// Compute maturity values for type C policy
        /// </summary>
        /// <param name="policy">Policy properties</param>
        /// <returns>Maturity value</returns>s
        private Maturity ComputeMaturityForTypeC(Policy policy)
        {
            long bonus = policy.Date < new DateTime(1990, 1, 1) && policy.Membership ? policy.DiscretionaryBonus : 0;

            Maturity policyMaturityValue = new Maturity
            {
                Number = policy.Number,
                Value = TruncateDecimal(((policy.Premiums - (policy.Premiums * ManagementFeeTypeC)) + bonus) * (policy.UpliftPercentage / 100 + 1), 2)
            };

            return policyMaturityValue;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get insurance policies 
        /// </summary>
        /// <returns>List of Policy details</returns>
        public List<Policy> GetPolicies()
        {
            var policies = ModelConverter.ConvertObject(PoliciesData.GetPolicies());

            return policies;
        }

        /// <summary>
        /// Compute policies maturity
        /// </summary>
        /// <returns>List of Policy Maturity details</returns>
        public List<Maturity> ComputeMaturity()
        {
            var policies = ModelConverter.ConvertObject(PoliciesData.GetPolicies());

            List<Maturity> result = ComputeMaturityValues(policies);

            PoliciesData.CreateXmlFile(ModelConverter.ConvertObject(result));

            return result;
        }
        #endregion
    }
}
