using System;
namespace Infrastrucutre
{
    public interface IDependencyFactory
    {
        void RegisterInstance<TInterfaceType>(TInterfaceType instance);
        TContainer Container<TContainer>();
        TClassType Resolve<TClassType>(string name);
        void RegisterType<TInterfaceType, TClassType>() where TClassType : TInterfaceType;
        void RegisterType<TInterfaceType, TClassType>(string name) where TClassType : TInterfaceType;
    }
}
