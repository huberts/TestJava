using System.Reflection;
using System.Runtime.Loader;

namespace TestJava;

internal class GiraAssemblyLoadContext : AssemblyLoadContext
{
  private readonly string _customPath;

  internal GiraAssemblyLoadContext(string customPath)
  {
    _customPath = customPath;
  }

  internal Assembly? ResolveAssembly(object? sender, ResolveEventArgs args)
  {
    var assemblyName = new AssemblyName(args.Name);
    var assemblyPath = Path.Combine(_customPath, assemblyName.Name + ".dll");
    return File.Exists(assemblyPath) ? Assembly.LoadFile(assemblyPath) : null;
  }
}