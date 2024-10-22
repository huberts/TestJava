using SysthermNet;

namespace TestJava;

public class GiraNetCoreSetup
{
  public static void Execute(string giPath, string dbPath)
  {
    IDictionary<Product, string> productPaths = new Dictionary<Product, string>()
    {
      { Product.CommonUserManager, dbPath },
      { Product.GeoinfoMapa, giPath }
    };

    IDictionary<string, string> config = new Dictionary<string, string>();

    GiRA.Setup(
      new Dictionary<Product, string>(productPaths),
      new Dictionary<string, string>(config));
  }
}