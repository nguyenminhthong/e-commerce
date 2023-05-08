using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Net.Assembly
{
    public class AssemblyFinder
    {
        private const string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^Autofac|^AutoMapper|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|netstandard|Azure.*";

        public string ClassNameSkipLoad { get; private set; } = "^System|^Microsoft|netstandard";

        protected IList<System.Reflection.Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                            .Where(assembly => !String.IsNullOrEmpty(assembly.FullName) && !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern)).Distinct().ToList();
        }

    }
}
