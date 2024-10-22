using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysthermNet;

namespace TestJava;

internal class Test
{
  public void DoTest(string user, string pass, string alias)
  {
    var filePath = "hiena.dxf";
    var destinationFilePath = "hiena.png";
    var coordinates = new List<double>
    {
      5751297.5,
      6476958.34387257,
      5751430.0087115,
      6477132.78
    };

    using var connection = CreateNewConnection(user, pass, alias);

    GeometryFunctions.DxfToGif(
      connection,
      coordinates[0],
      coordinates[1],
      coordinates[2],
      coordinates[3],
      GetDpi(300, coordinates[0], coordinates[2]),
      filePath,
      destinationFilePath,
      isWithOriginalColors: true);
  }

  Connection CreateNewConnection(string userName, string password, string linkName)
  {
    var cumData = CommonUserManager.LogOn(userName, password, null);
    var link = cumData.ApplicationLinks.Single(x => x.Name == linkName);
    var connection = new Connection(userName, password, link.ConnectionString, linkName, "");

    connection.AllowEdiUsage();

    return connection;


  }

  static int GetDpi(double width, double xMin, double xMax)
  {
    const double scale = 0.5;
    const double inchSize = 25.4;
    return Math.Max((int)(width / (xMax - xMin) * scale * inchSize), 30);
  }

}