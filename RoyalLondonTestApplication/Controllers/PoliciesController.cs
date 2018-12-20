#region Used Namespaces
using RoyalLondonTestApplication.Business.Interfaces;
using RoyalLondonTestApplication.Helpers;
using RoyalLondonTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
#endregion

namespace RoyalLondonTestApplication.Controllers
{
    public class PoliciesController : Controller
    {
        #region Properties
        /// <summary>
        /// Policies business component
        /// </summary>
        private IPoliciesComponent PoliciesComponent { get; set; }
        #endregion

        #region Constructor
        public PoliciesController(IPoliciesComponent policiesComponent)
        {
            this.PoliciesComponent = policiesComponent;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get policies
        /// </summary>
        /// <returns>Action result for policies</returns>
        public ActionResult GetPolicies()
        {
            List<Policy> policies = ModelConverter.ConvertObject(PoliciesComponent.GetPolicies());

            return View("GetPolicies", policies);
        }

        /// <summary>
        /// Get policies maturity
        /// </summary>
        /// <returns>Action result for policies maturity</returns>
        public ActionResult GetPoliciesMaturity()
        {
            List<Maturity> policiesMaturity = ModelConverter.ConvertObject(PoliciesComponent.ComputeMaturity());

            return View("GetPoliciesMaturity", policiesMaturity);
        }
        #endregion
    }
}