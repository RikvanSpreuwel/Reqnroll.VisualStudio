﻿using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowConnector.SpecFlowProxies;

public class BindingAssemblyContextLoader : IBindingAssemblyLoader
{
    private readonly AssemblyLoadContext _assemblyLoadContext;

    public BindingAssemblyContextLoader(AssemblyLoadContext assemblyLoadContext)
    {
        _assemblyLoadContext = assemblyLoadContext;
    }

    public Assembly Load(string assemblyName)
    {
        return _assemblyLoadContext.LoadFromAssemblyName(new AssemblyName(assemblyName));
    }
}
