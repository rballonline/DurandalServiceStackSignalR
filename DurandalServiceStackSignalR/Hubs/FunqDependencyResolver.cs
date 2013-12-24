using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Funq;
using Microsoft.AspNet.SignalR;

namespace DurandalServiceStackSignalR.Hubs
{
    public class FunqDependencyResolver : DefaultDependencyResolver
    {
        private readonly MethodInfo _tryResolveMethod;
        private Container _container;
        
        public FunqDependencyResolver(Container container)
        {
            _container = container;

            FunqDependencyResolver existingResolver = container.TryResolve<IDependencyResolver>() as FunqDependencyResolver;
            if (existingResolver != null)
            {
                existingResolver._container = container;
            }
            else
            {
                container.Register<IDependencyResolver>(c => this);
            }

            _tryResolveMethod = container
                .GetType()
                .GetMethods()
                .First(m => m.Name == "TryResolve" && m.IsGenericMethodDefinition && m.GetGenericArguments().Length == 1);
        }

        public override object GetService(Type serviceType)
        {
            var instance = _tryResolveMethod.MakeGenericMethod(serviceType).Invoke(_container, null);
            if (instance != null)
            {
                return instance;
            }

            return base.GetService(serviceType);
        }
        
        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var instance = _tryResolveMethod.MakeGenericMethod(typeof(IEnumerable<>).MakeGenericType(serviceType)).Invoke(_container, null);
            if (instance != null)
            {
                return (IEnumerable<object>)instance;
            }

            return base.GetServices(serviceType) ?? Enumerable.Empty<object>();
        }
    }
}