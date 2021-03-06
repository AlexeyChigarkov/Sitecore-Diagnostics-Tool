namespace Sitecore.DiagnosticsTool.TestRunner.Base
{
  using System.Collections.Generic;
  using JetBrains.Annotations;
  using Sitecore.DiagnosticsTool.Core.Collections;
  using Sitecore.DiagnosticsTool.Core.DataProviders;

  public sealed class ResultsFile
  {
    [NotNull]
    [UsedImplicitly]
    public Dictionary<string, ITestReport[]> Instances { get; } = new Dictionary<string, ITestReport[]>();

    [CanBeNull]
    public Map<IDataProvider> Packages { [UsedImplicitly] get; set; }

    public ITestReport[] Solution
    {
      get
      {
        if (!Instances.ContainsKey(""))
        {
          Instances.Add("", new ITestReport[0]);
        }

        return Instances[""];
      }

      set
      {
        if (!Instances.ContainsKey(""))
        {
          Instances.Add("", value);
        }
        else
        {
          Instances[""] = value;
        }
      }
    }
  }
}