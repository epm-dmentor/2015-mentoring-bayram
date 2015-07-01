using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace Epam.Sdesk.SelfHostedApp
{
    public class CustomAssemblyResolver:IAssembliesResolver
    {
        private string _path;
    public CustomAssemblyResolver(string path)
    {
        _path = path;
    }

    ICollection<Assembly> IAssembliesResolver.GetAssemblies()
    {
        List<Assembly> assemblies = new List<Assembly>();
        assemblies.Add(Assembly.LoadFrom(_path));
        return assemblies;
    }
    }
}
