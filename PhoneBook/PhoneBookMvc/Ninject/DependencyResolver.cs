using EntityServices;
using EntityServices.Services;
using InfrastructureData;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookMvc.Ninject
{
    public class DependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public DependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {

            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IPhoneNumberReposirory>().To<PhoneNumberReposirory>();
        }
    }
}