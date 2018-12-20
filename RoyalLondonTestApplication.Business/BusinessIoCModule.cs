#region Used namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using RoyalLondonTestApplication.Business.Components;
using RoyalLondonTestApplication.Business.Interfaces;
using RoyalLondonTestApplication.DataAccess;
using Module = Autofac.Module;
#endregion

namespace RoyalLondonTestApplication.Business
{
    /// <summary>
    /// Business Components IoC module
    /// </summary>
    public class BusinessIoCModule : Module
    {
        #region Protected Methods
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataIoCModule>();
            builder.RegisterType<PoliciesComponent>().As<IPoliciesComponent>();
            base.Load(builder);
        }
        #endregion
    }
}
