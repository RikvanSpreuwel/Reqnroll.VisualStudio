﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using SpecFlow.VisualStudio.SpecFlowConnector.Discovery.V38;
using TechTalk.SpecFlow;

namespace SpecFlow.VisualStudio.SpecFlowConnector.Discovery
{
    public class VersionSelectorDiscoverer : ISpecFlowDiscoverer
    {
        private readonly AssemblyLoadContext _loadContext;
        private ISpecFlowDiscoverer _discoverer;

        public VersionSelectorDiscoverer(AssemblyLoadContext loadContext)
        {
            _loadContext = loadContext;
        }

        public string Discover(Assembly testAssembly, string testAssemblyPath, string configFilePath)
        {
            if (_discoverer == null)
                _discoverer = CreateDiscoverer();

            return _discoverer.Discover(testAssembly, testAssemblyPath, configFilePath);
        }

        public void Dispose()
        {
            _discoverer?.Dispose();
            _discoverer = null;
        }

        private ISpecFlowDiscoverer CreateDiscoverer()
        {
            var specFlowVersion = GetSpecFlowVersion();

            var discovererType = typeof(SpecFlowV38Discoverer); // assume recent version
            if (specFlowVersion != null)
            {
                var versionNumber =
                    ((specFlowVersion.FileMajorPart * 100) + specFlowVersion.FileMinorPart) * 1000 + specFlowVersion.FileBuildPart;

                if (versionNumber >= 3_09_022)
                    discovererType = typeof(SpecFlowV38Discoverer);
                else
                    throw new NotSupportedException($"The SpecFlow version {specFlowVersion.FileMajorPart}.{specFlowVersion.FileMinorPart}.{specFlowVersion.FileBuildPart} is not supported by this connector.");
            }

            return (ISpecFlowDiscoverer)Activator.CreateInstance(discovererType, new object[] { _loadContext });
        }

        private FileVersionInfo GetSpecFlowVersion()
        {
            var specFlowAssembly = typeof(ScenarioContext).Assembly;
            var specFlowAssemblyPath = specFlowAssembly.Location;
            var fileVersionInfo = File.Exists(specFlowAssemblyPath) ? FileVersionInfo.GetVersionInfo(specFlowAssemblyPath) : null;
            return fileVersionInfo;
        }
    }
}
