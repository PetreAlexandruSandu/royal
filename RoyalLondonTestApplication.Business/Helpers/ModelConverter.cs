#region Used Namespaces
using RoyalLondonTestApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace RoyalLondonTestApplication.Business.Helpers
{
    /// <summary>
    /// Convert business/data access objects to data access/business objects.
    /// </summary>
    internal static class ModelConverter
    {
        /// <summary>
        /// Convert Policy model
        /// </summary>
        /// <param name="model">Policy details</param>
        /// <returns>Policy details</returns>
        public static Policy ConvertObject(DataAccess.Models.Policy model)
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
        public static List<Policy> ConvertObject(List<DataAccess.Models.Policy> model)
        {
            return model.Select(x => ConvertObject(x)).ToList();
        }

        /// <summary>
        /// Convert Maturity model
        /// </summary>
        /// <param name="model">Maturity details</param>
        /// <returns>Maturity details</returns>
        public static DataAccess.Models.Maturity ConvertObject(Maturity model)
        {
            return model == null ? null : new DataAccess.Models.Maturity
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
        /// Convert list of Maturity models
        /// </summary>
        /// <param name="model">List of Maturity details</param>
        /// <returns>List of Maturity details</returns>
        public static List<DataAccess.Models.Maturity> ConvertObject(List<Maturity> model)
        {
            return model.Select(x => ConvertObject(x)).ToList();
        }
    }
}
