using TestJava;

Console.WriteLine("Hello, World!");

var giPath = "D:/workspace/GEOINFO/Mapa/App32";
var dbPath = "D:/workspace/GEOINFO/UserMgr/App32/CommonUserManager";
var user = "h-slupca";
var pass = "q";
var alias = "NO_SLUPCA";



AppDomain.CurrentDomain.AssemblyResolve += new GiraAssemblyLoadContext(giPath).ResolveAssembly;
AppDomain.CurrentDomain.AssemblyResolve += new GiraAssemblyLoadContext(dbPath).ResolveAssembly;

GiraNetCoreSetup.Execute(giPath, dbPath);

var test = new Test();
test.DoTest(user, pass, alias);




