using System;

public interface IDependencyFactory
{
    void RegisterType<TInterfaceType, TClassType>(string name) where TClassType : TInterfaceType;
}
