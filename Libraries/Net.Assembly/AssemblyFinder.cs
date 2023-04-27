using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Assembly
{
    public class AssemblyFinder
    {
        #region Field
        private readonly IFileProvider _fileProvider;
        #endregion

        #region Properties
        
        public List<Type> Assemblies { get; private set; }

        #endregion

        #region Ctor
        public AssemblyFinder()
        {
            Assemblies = new List<Type>();
        }

        #endregion

        protected void LoadAssemblies(string directoryPath)
        {
        }
    }
}
