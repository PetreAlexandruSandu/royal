using RoyalLondonTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalLondonTestApplication.Helpers
{
    /// <summary>
    /// Convert business objects to view model objects.
    /// </summary>
    internal static class ModelConverter
    {
        /// <summary>
        /// Convert Policy model
        /// </summary>
        /// <param name="model">Policy details</param>
        /// <returns>Policy details</returns>
        public static Policy ConvertObject(Business.Models.Policy model)
        {
            return model == null ? null : new Policy
            {
                Date = model.Date,
                DiscretionaryBonus = model.DiscretionaryBonus,
                Membership = model.Membership,
                Number = model.Number,
                Premiums = model.Premiums,
                UpliftPercentage = model.UpliftPercentage
            };
        }

        /// <summary>
        /// Convert list of Policy models
        /// </summary>
        /// <param name="model">List of Policy details</param>
        /// <returns>List of Policy details</returns>
        public static List<Policy> ConvertObject(List<Business.Models.Policy> model)
        {
            return model.Select(x => ConvertObject(x)).ToList();
        }

        /// <summary>
        /// Convert Policy Maturity model
        /// </summary>
        /// <param name="model">Policy Maturity details</param>
        /// <returns>Policy Maturity details</returns>
        public static Maturity ConvertObject(Business.Models.Maturity model)
        {
            return model == null ? null : new Maturity
            {
                Date = model.Date,
                DiscretionaryBonus = model.DiscretionaryBonus,
                Membership = model.Membership,
                Number = model.Number,
                Premiums = model.Premiums,
                UpliftPercentage = model.UpliftPercentage,
                Value = model.Value
            };
        }

        /// <summary>
        /// Convert list of Policy Maturity models
        /// </summary>
        /// <param name="model">List of Policy Maturity details</param>
        /// <returns>List of Policy Maturity details</returns>
        public static List<Maturity> ConvertObject(List<Business.Models.Maturity> model)
        {
            return model.Select(x => ConvertObject(x)).ToList();
        }
    }
}