﻿namespace SpecFlowConnector.SpecFlowProxies;

public class BindingRegistryFactoryBeforeV307013 : BindingRegistryFactoryBeforeV309022
{
    public BindingRegistryFactoryBeforeV307013(ILogger log) : base(log)
    {
    }

    protected override object CreateDependencyProvider(AssemblyLoadContext assemblyLoadContext)
        => new SpecFlowDependencyProviderBeforeV307013(assemblyLoadContext);

    protected override object PrepareTestRunnerCreation(
        IObjectContainer globalContainer,
        AssemblyLoadContext assemblyLoadContext)
        => globalContainer;
}
