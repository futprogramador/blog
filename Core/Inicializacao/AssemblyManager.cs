using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class AssemblyManager
    {
        public static string ExecutionPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"); }
        }

        public static IEnumerable<Assembly> GetInfrastructures()
        {
            return GetAssemblies("*Infraestrutura.dll");
        }

        public static IEnumerable<Assembly> GetAssemblies(string searchPattern)
        {
            return Directory.GetFiles(ExecutionPath, searchPattern).Select(assembly => Assembly.LoadFile(assembly));
        }
    }
}
