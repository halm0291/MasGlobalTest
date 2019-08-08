using Infrastrucutre;
using System;
using Unity;

namespace AppInfrastructure.DependencyInjection
{
    public class UnityDependencyFactory : IDependencyFactory
    {
        private static IUnityContainer Container { get; }

        static UnityDependencyFactory()
        {
            Container = new UnityContainer();
        }
        TContainer IDependencyFactory.Container<TContainer>()
        {
            return (TContainer)Container;
        }

        public void RegisterType<TInterfaceType, TClassType>(string name) where TClassType : TInterfaceType
        {
            Container.RegisterType<TInterfaceType, TClassType>(name);
        }

        public void RegisterType<TInterfaceType, TClassType>() where TClassType : TInterfaceType
        {
            Container.RegisterType<TInterfaceType, TClassType>();
        }

        public TClassType Resolve<TClassType>(string name)
        {
            return Container.Resolve<TClassType>(name);
        }

        public void RegisterInstance<TInterfaceType>(TInterfaceType instance)
        {
            Container.RegisterInstance(instance);
        }
    }
}
