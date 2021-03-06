﻿namespace Sitecore.DiagnosticsTool.Core.Extensions
{
  using System;
  using System.Linq;
  using System.Xml;
  using JetBrains.Annotations;
  using Sitecore.Diagnostics.Base;
  using Sitecore.Diagnostics.Logging;

  public static class XmlExtensions
  {
    [PublicAPI]
    public static XmlDocument TryLoadFile([NotNull] this XmlDocument document, [NotNull] string path)
    {
      try
      {
        Assert.ArgumentNotNull(document, nameof(document));
        Assert.ArgumentNotNull(path, nameof(path));
        document.Load(path);
        return document;
      }
      catch (Exception ex)
      {
        Log.Error(ex, $"Failed to load XML file: {path}");

        return null;
      }
    }

    [NotNull]
    [PublicAPI]
    public static XmlElement[] SelectElements([NotNull] this XmlDocument document, [NotNull] string xpath)
    {
      Assert.ArgumentNotNull(document, nameof(document));
      Assert.ArgumentNotNull(xpath, nameof(xpath));

      var element = document.DocumentElement;
      Assert.IsNotNull(element, "element");

      return SelectElements(element, xpath);
    }

    [NotNull]
    [PublicAPI]
    public static XmlElement[] SelectElements([NotNull] this XmlElement element, [NotNull] string xpath)
    {
      Assert.ArgumentNotNull(element, nameof(element));
      Assert.ArgumentNotNull(xpath, nameof(xpath));

      var nodes = element.SelectNodes(xpath);
      if (nodes == null)
      {
        return new XmlElement[0];
      }

      return nodes.OfType<XmlElement>().ToArray();
    }

    [PublicAPI]
    public static XmlElement SelectSingleElement([NotNull] this XmlDocument document, [NotNull] string xpath)
    {
      Assert.ArgumentNotNull(document, nameof(document));
      Assert.ArgumentNotNull(xpath, nameof(xpath));

      return document.SelectSingleNode(xpath) as XmlElement;
    }

    [NotNull]
    [PublicAPI]
    public static XmlElement[] GetChildren([NotNull] this XmlElement element)
    {
      Assert.ArgumentNotNull(element, nameof(element));

      return element
        .ChildNodes
        .OfType<XmlElement>()
        .ToArray();
    }

    [PublicAPI]
    public static XmlDocument TryParse([NotNull] this XmlDocument that, [NotNull] string xml)
    {
      try
      {
        Assert.ArgumentNotNull(that, nameof(that));
        Assert.ArgumentNotNull(xml, nameof(xml));

        that.LoadXml(xml);
        return that;
      }
      catch (Exception ex)
      {
        Log.Error(ex, $"Failed to load XML: {xml}");

        return null;
      }
    }

    [NotNull]
    public static XmlDocument Parse([NotNull] this XmlDocument that, [NotNull] string xml)
    {
      Assert.ArgumentNotNull(that, nameof(that));
      Assert.ArgumentNotNull(xml, nameof(xml));

      that.LoadXml(xml);
      return that;
    }
  }
}