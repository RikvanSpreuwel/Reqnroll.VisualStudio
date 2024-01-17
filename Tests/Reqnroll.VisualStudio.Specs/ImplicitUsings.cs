global using FluentAssertions;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.CSharp.Syntax;
global using Microsoft.VisualStudio.Language.Intellisense;
global using Microsoft.VisualStudio.Text;
global using Microsoft.VisualStudio.Text.Editor;
global using Microsoft.VisualStudio.Text.Tagging;
global using Microsoft.VisualStudio.Threading;
global using Moq;
global using Reqnroll.SampleProjectGenerator;
global using Reqnroll.VisualStudio.Common;
global using Reqnroll.VisualStudio.Configuration;
global using Reqnroll.VisualStudio.Diagnostics;
global using Reqnroll.VisualStudio.Discovery;
global using Reqnroll.VisualStudio.Editor.Commands.Infrastructure;
global using Reqnroll.VisualStudio.Editor.Commands;
global using Reqnroll.VisualStudio.Editor.Completions;
global using Reqnroll.VisualStudio.Editor.Completions.Infrastructure;
global using Reqnroll.VisualStudio.Editor.Services;
global using Reqnroll.VisualStudio.Editor.Services.Formatting;
global using Reqnroll.VisualStudio.Editor.Services.EditorConfig;
global using Reqnroll.VisualStudio.Editor.Traceability;
global using Reqnroll.VisualStudio.ProjectSystem.Configuration;
global using Reqnroll.VisualStudio.ProjectSystem;
global using Reqnroll.VisualStudio.ProjectSystem.Settings;
global using Reqnroll.VisualStudio.ReqnrollConnector.Models;
global using Reqnroll.VisualStudio.Specs.Support;
global using Reqnroll.VisualStudio.UI.ViewModels;
global using Reqnroll.VisualStudio.VsxStubs.ProjectSystem;
global using Reqnroll.VisualStudio.VsxStubs.StepDefinitions;
global using Reqnroll.VisualStudio.VsxStubs;
global using System.Diagnostics;
global using System.Reflection;
global using System.Text;
global using System.Text.RegularExpressions;
global using Reqnroll;
global using Reqnroll.Assist;
global using Xunit;
global using Xunit.Abstractions;