﻿using System;
using SpecFlow.VisualStudio.SpecFlowConnector.Generation;

namespace SpecFlow.VisualStudio.SpecFlowConnector;

public static class GeneratorCommand
{
    public const string CommandName = "generate";

    public static string Execute(string[] commandArgs)
    {
        var options = GenerationOptions.Parse(commandArgs);
        var processor = new GenerationProcessor(options);
        return processor.Process();
    }
}
