#region Used Namespaces
using Autofac;
using RoyalLondonTestApplication.DataAccess.Components;
using RoyalLondonTestApplication.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module; 
#endregion

namespace RoyalLondonTestApplication.DataAccess
{
    /// <summary>
	/// Data Access Component - IoC module
	/// </summary>
	public class DataIoCModule : Module
    {
        #region Protected Methods
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PoliciesData>().As<IPoliciesData>();
            base.Load(builder);
        }
        #endregion
    }
}
