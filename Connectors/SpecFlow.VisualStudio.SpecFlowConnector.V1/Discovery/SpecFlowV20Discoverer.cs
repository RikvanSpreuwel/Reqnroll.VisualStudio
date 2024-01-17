﻿#nullable disable
namespace SpecFlow.VisualStudio.SpecFlowConnector.Discovery;

public class SpecFlowV20Discoverer : SpecFlowV21Discoverer
{
    protected override object CreateGlobalContainer(Assembly testAssembly, string configFilePath)
    {
        var testRunContainerBuilderType = typeof(ITestRunner).Assembly
            .GetType("TechTalk.SpecFlow.Infrastructure.TestRunContainerBuilder", true);
        var testRunContainerBuilder =
            testRunContainerBuilderType.ReflectionCreateInstance<object>(
                new[] {typeof(IDefaultDependencyProvider)}, new object[] {null});
        var container = testRunContainerBuilder.ReflectionCallMethod<object>(
            "CreateContainer", new[] {typeof(IRuntimeConfigurationProvider)}, new object[] {null});
        return container;
    }

    protected override IEnumerable<IStepDefinitionBinding> GetStepDefinitions(IBindingRegistry bindingRegistry) =>
        bindingRegistry.GetConsideredStepDefinitions(StepDefinitionType.Given)
            .Concat(bindingRegistry.GetConsideredStepDefinitions(StepDefinitionType.When))
            .Concat(bindingRegistry.GetConsideredStepDefinitions(StepDefinitionType.Then));
}
